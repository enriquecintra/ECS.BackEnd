using BackEnd.MongoDB;
using BackEnd.MongoDB.Entities;

namespace BackEnd.Repositories
{
    public class TransactionRepository : RepositoryBase<TransactionEntity>
    {
        public TransactionRepository(MongoDBConnection cn) : base(cn)
        {
        }
    }
}
