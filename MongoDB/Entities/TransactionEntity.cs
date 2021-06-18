using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BackEnd.MongoDB.Entities
{
    public class TransactionEntity : EntityBase
    {
        [BsonElement("date")]
        [BsonRequired()]
        public DateTime Date { get; set; }
        [BsonElement("income")]
        [BsonRequired()]
        public double Income { get; set; }
        [BsonElement("outflow")]
        [BsonRequired()]
        public double Outflow { get; set; }
        [BsonElement("description")]
        [BsonRequired()]
        public string Description { get; set; }
        [BsonElement("user")]
        [BsonRequired()]
        public UserEntity User { get; internal set; }
    }
}
