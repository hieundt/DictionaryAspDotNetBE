using System.Text.Json.Serialization;
using DictionaryApi.DataAccess.CollectionNaming;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DictionaryApi.Domain
{
    [BsonCollection("user")]
    public class User : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = String.Empty;

        [BsonElement("password")]
        public string Password { get; set; } = String.Empty;

        [BsonElement("userName")]
        public string UserName { get; set; } = String.Empty;

        [BsonElement("dateOfBirth")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

    }
}
