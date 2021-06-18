using BackEnd.Models;
using BackEnd.MongoDB;
using BackEnd.MongoDB.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Repositories
{
    public abstract class RepositoryBase<T> where T : EntityBase
    {
        protected readonly IMongoCollection<T> _collection;
        public RepositoryBase(MongoDBConnection cn)
        {
            _collection = cn.Database.GetCollection<T>(GetCollectionName());
        }

        private string GetCollectionName()
        {
            var name = typeof(T);
            return name.Name.Replace("Entity", "").ToLower();
        }

        public async Task<T> CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entity.Created = DateTime.UtcNow;
            entity.Updated = DateTime.UtcNow;

            await _collection.InsertOneAsync(entity);

            return entity;
        }

        public async Task<T> UpdateAsync(ObjectId id, T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.Updated = DateTime.UtcNow;
            await _collection.ReplaceOneAsync(e => e.ObjectId.Equals(id), entity);
            return entity;
        }


        public Task<T> Get(ObjectId objectId)
        {
            var filter = Builders<T>.Filter.Eq(c => c.ObjectId, objectId);
            var entity = _collection.Find(filter).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> Get(FilterDefinition<T> filter)
        {
            var result = await _collection.Find(filter).ToListAsync();
            return result;
        }

        public async Task<Page<T>> Get(FilterDefinition<T> filter, SortDefinition<T> sort, int pageNumber = 1, int pageSize = 10)
        {
            var query = _collection.Find(filter);

            var totalRecords = query.CountDocumentsAsync();

            var records = query.Sort(sort).Skip((pageNumber - 1) * pageSize).Limit(pageSize).ToListAsync();

            await Task.WhenAll(totalRecords, records);

            var result = new Page<T>()
            {
                Records = records.Result,
                RecordsTotal = totalRecords.Result,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            result.TotalPages = (int)Math.Ceiling((double)result.RecordsTotal / result.PageSize);
            return result;
        }

        public async Task DeleteAsync(ObjectId id)
        {
            await _collection.DeleteOneAsync(p => p.ObjectId.Equals(id));
        }
    }
}
