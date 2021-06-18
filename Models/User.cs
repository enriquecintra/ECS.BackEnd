using BackEnd.Filters;
using System;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class User
    {
        [SwaggerIgnore]
        public string Id { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        [RegularExpression(@"^.*(?=.{8,})(?=.*[@!*#$%^&+=])(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$", ErrorMessage = "Password deve conter no mínimo oito caracteres, pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        [DateLessThanValidation(18, ErrorMessage = "Somente maiores de 18 anos")]
        public DateTime BirthDate { get; set; }
        [SwaggerIgnore]
        public string Role { get; set; }
    }
}
