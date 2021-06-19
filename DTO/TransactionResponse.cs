using System;

namespace BackEnd.DTO
{
    public class TransactionResponse
    {
        public DateTime Date { get; set; }
        public double Income { get; set; }
        public double Outflow { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
    }
}
