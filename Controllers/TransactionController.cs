using BackEnd.Filters;
using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/v1/transaction")]
    public class TransactionController : Controller
    {
        public readonly TransactionService _service;
        public readonly IDistributedCache _cache; 
        public TransactionController(TransactionService service, IDistributedCache cache)
        {
            _service = service;
            _cache = cache;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] Transaction model)
        {
            var user = Utils.GetUserContext(this.User);
            model.User = user;
            var entity = await _service.Create(model);
            AtualizaCache(model);
            return Ok(entity);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] Transaction model)
        {
            var user = Utils.GetUserContext(this.User);
            model.User = user;
            var entity = await _service.Update(model);
            AtualizaCache(model);
            return Ok(entity);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] string description, DateTime? date, double? income, double? outflow, int pageNumber = 1, int pageSize = 10)
        {
            var page = await _service.Get(description, date, income, outflow, pageNumber, pageSize);

            string valorBalance = _cache.GetString("Balance");
            if (valorBalance == null)
            {
                var balance = page.Records.Sum(s => s.Income - s.Outflow);
                valorBalance = balance.ToString();
                _cache.SetString("Balance", valorBalance);
            }

            return Ok(
                new { 
                    page.Records,
                    page.RecordsTotal,
                    page.PageNumber,
                    page.PageSize,
                    page.TotalPages,
                    balance = valorBalance
            });
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var entity = await _service.Get(id);

            return Ok(entity);
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await _service.Delete(id);

            return Ok(new { success = true });
        }


        private void AtualizaCache(Transaction model)
        {
            var valor = model.Income - model.Outflow;
            var valorBalance = _cache.GetString("Balance");
            if (valorBalance == null) {
                valorBalance = valor.ToString();
            }
            else {
                valorBalance = (double.Parse(valorBalance) + valor).ToString();
            }
            _cache.SetString("Balance", valorBalance);
        }
    }
}
