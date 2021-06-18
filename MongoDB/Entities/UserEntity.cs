using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.MongoDB.Entities
{
    public class UserEntity : EntityBase
    {
        [BsonElement("login")]
        [BsonRequired()]
        public string Login { get; set; }
        [BsonElement("password")]
        [BsonRequired()]
        public string Password { get; set; }
        [BsonElement("name")]
        [BsonRequired()]
        public string Name { get; set; }
        [BsonElement("email")]
        [BsonRequired()]
        public string Email { get; set; }
        [BsonElement("birthDate")]
        [BsonRequired()]
        public DateTime BirthDate { get; set; }
        [BsonElement("role")]
        public string Role { get; internal set; }
    }
}
