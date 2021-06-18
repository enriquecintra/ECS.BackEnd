using AutoMapper;
using BackEnd.Models;
using BackEnd.MongoDB.Entities;
using BackEnd.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class TransactionService
    {
        public readonly TransactionRepository _repository;
        public readonly IMapper _mapper;
        public TransactionService(TransactionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Transaction> Create(Transaction model)
        {
            var result = await _repository.CreateAsync(_mapper.Map<TransactionEntity>(model));
            return _mapper.Map<Transaction>(result); ;
        }

        internal async Task<Transaction> Update(Transaction model)
        {
            var result = await _repository.UpdateAsync(ObjectId.Parse(model.Id), _mapper.Map<TransactionEntity>(model));
            return _mapper.Map<Transaction>(result); ;
        }

        internal async Task<Page<Transaction>> Get(string description, DateTime? date, double? income, double? outflow, int pageNumber = 1, int pageSize = 10)
        {
            var builder = Builders<TransactionEntity>.Filter;
            var filter = builder.Empty;
            if (!string.IsNullOrEmpty(description))
                filter &= builder.Text(description);
            if (date.HasValue)
                filter &= builder.Eq(x => x.Date.Date, date.Value.Date);
            if (income.HasValue)
                filter &= builder.Eq(x => x.Income, income.Value);
            if (outflow.HasValue)
                filter &= builder.Eq(x => x.Outflow, outflow.Value);

            var result = await _repository.Get(filter, Builders<TransactionEntity>.Sort.Ascending(o => o.Date), pageNumber, pageSize);

            var mapeado = result.MapearModel<Transaction>(_mapper);

            return mapeado;
        }

        internal async Task<Transaction> Get(string id)
        {
            var result = await _repository.Get(ObjectId.Parse(id));
            return _mapper.Map<Transaction>(result); ;
        }

        internal async Task Delete(string id)
        {
            await _repository.DeleteAsync(ObjectId.Parse(id));
        }
    }
}
