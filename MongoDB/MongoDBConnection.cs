using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BackEnd.MongoDB
{
    public class MongoDBConnection
    {
        public IMongoDatabase Database { get; private set; }
        
        public MongoDBConnection(IMongoClient client)
        {
            Database = client.GetDatabase(Startup.StaticConfig.GetConnectionString("Database"));
        }
    }
}
