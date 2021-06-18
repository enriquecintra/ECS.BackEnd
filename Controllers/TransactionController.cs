using BackEnd.Filters;
using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/v1/transaction")]
    public class TransactionController : Controller
    {
        public readonly TransactionService _service;
        public TransactionController(TransactionService service)
        {
            _service = service;
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] Transaction model)
        {
            var user = Utils.GetUserContext(this.User);

            model.User = user;

            var entity = await _service.Create(model);

            return Ok(entity);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] Transaction model)
        {
            var user = Utils.GetUserContext(this.User);

            model.User = user;

            var entity = await _service.Update(model);

            return Ok(entity);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] string description, DateTime? date, double? income, double? outflow, int pageNumber = 1, int pageSize = 10)
        {
            var entities = await _service.Get(description, date, income, outflow, pageNumber, pageSize);
            return Ok(entities);
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
    }
}
