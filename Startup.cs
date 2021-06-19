using BackEnd.Filters;
using BackEnd.MongoDB;
using BackEnd.Repositories;
using BackEnd.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            StaticConfig = configuration;
        }

        public IConfiguration Configuration { get; }
        public static IConfiguration StaticConfig { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDistributedRedisCache(options =>
            {
                options.Configuration =
                    Configuration.GetConnectionString("Redis");
                options.InstanceName = "BackEnd-Cache-";
            });


            services.AddCors();

            services.AddControllers(options => {
                options.Filters.Add(typeof(ValidateModelAttribute));
            });

            services.AddSwaggerGen(c =>
            {
                c.SchemaFilter<SwaggerIgnoreFilter>();

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Bearer [apiToken]",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                    },
                    new List<string>() }
                });

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BackEnd", Version = "v1" });
                
            });

            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("Settings:secretKey"));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSingleton<IMongoClient, MongoClient>(sp => new MongoClient(Configuration.GetConnectionString("MongoDb")));
            services.AddSingleton<MongoDBConnection>();

            services.AddSingleton<UserRepository>();
            services.AddSingleton<TransactionRepository>();

            services.AddSingleton<UserService>();
            services.AddSingleton<TransactionService>();


            var config = new AutoMapper.MapperConfiguration(cfg =>
            {

                cfg.CreateMap<ObjectId, string>().ConvertUsing(o => o.ToString());
                cfg.CreateMap<string, ObjectId>().ConvertUsing(s => string.IsNullOrEmpty(s) ? ObjectId.GenerateNewId() : ObjectId.Parse(s));

                cfg.CreateMap<MongoDB.Entities.UserEntity, Models.User>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ObjectId)).ReverseMap();
                cfg.CreateMap<MongoDB.Entities.TransactionEntity, Models.Transaction>()
                            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ObjectId)).ReverseMap()
                            .ReverseMap();
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = "api-docs/swagger";
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackEnd");
                });

                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackEnd v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
