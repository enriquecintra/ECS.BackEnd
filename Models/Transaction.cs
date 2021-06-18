using BackEnd.Filters;
using System;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class Transaction
    {
        [SwaggerIgnore]
        public string Id { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        [Range(0, double.MaxValue, ErrorMessage = "Income precisa ser maior ou igual a 0.")]
        public double Income { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        [Range(0, double.MaxValue, ErrorMessage = "Outflow precisa ser maior ou igual a 0.")]
        public double Outflow { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        public string Description { get; set; }
        [SwaggerIgnore]
        public User User { get; internal set; }
    }
}
