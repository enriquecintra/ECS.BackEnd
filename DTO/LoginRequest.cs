using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTO
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Obrigatório")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        public string Password { get; set; }
    }
}
