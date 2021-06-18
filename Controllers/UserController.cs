using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/v1/user")]
    public class UserController : Controller
    {
        public readonly UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] User model)
        {
            if (await _service.Exists(model.Login))
            {
                return BadRequest(new { error = "Esse Login já existe." });
            }

            model.Id = "";
            var user = await _service.Create(model);
            return Ok(new
            {
                user
            });
        }
    }
}
