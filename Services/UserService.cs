using AutoMapper;
using BackEnd.Models;
using BackEnd.MongoDB.Entities;
using BackEnd.Repositories;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class UserService
    {
        public readonly UserRepository _repository;
        public readonly IMapper _mapper;
        public UserService(UserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<User> Get(string login, string password)
        {
            var result = await _repository.Get(Builders<UserEntity>.Filter.Where(x => x.Login.Equals(login) && x.Password.Equals(password)));
            return _mapper.Map<User>(result.FirstOrDefault());
        }
        public async Task<User> Create(User user)
        {
            var result = await _repository.CreateAsync(_mapper.Map<UserEntity>(user));
            return _mapper.Map<User>(result); ;
        }

        public async Task<bool> Exists(string login)
        {
            var result = await _repository.Get(Builders<UserEntity>.Filter.Where(x => x.Login.Equals(login)));
            return result.Any();
        }
    }
}
