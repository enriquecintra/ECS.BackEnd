using BackEnd.MongoDB;
using BackEnd.MongoDB.Entities;

namespace BackEnd.Repositories
{
    public class UserRepository : RepositoryBase<UserEntity>
    {
        public UserRepository(MongoDBConnection cn) : base(cn)
        {
        }
    }
}
