using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BackEnd.MongoDB.Entities
{
    public abstract class EntityBase
    {
        [BsonId()]
        public virtual ObjectId ObjectId { get; set; }

        [BsonElement("created")]
        [BsonRequired()]
        public DateTime Created { get; set; } = DateTime.Now;

        [BsonElement("updated")]
        [BsonRequired()] public DateTime Updated { get; set; } = DateTime.Now;
    }
}
