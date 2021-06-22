using BackEnd.DTO;
using BackEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/v1/auth")]
    public class AuthenticationController : Controller
    {
        public readonly UserService _service;
        public AuthenticationController(UserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Authenticated()
        {
            var user = Utils.GetUserContext(this.User);
            return Ok(new
            {
                user.Id,
                user.Name
            });
        }

        //[HttpGet]
        //[Route("user")]
        //[Authorize(Roles = "admin,user")]
        //public string UserRole() => "Usuário";

        //[HttpGet]
        //[Route("admin")]
        //[Authorize(Roles = "admin")]
        //public string AdminRole() => "Administrador";


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var user = await _service.Get(model.Username, model.Password);
            if (user == null)
                return NotFound(new { error = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Password = "";
            return Ok(new
            {
                token
            });
        }

    }
}
