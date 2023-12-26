using System.Text.Json.Serialization;
using DictionaryApi.DataAccess.CollectionNaming;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DictionaryApi.Domain
{
    [BsonCollection("option")]
    public class Option: BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("value")]
        public string Value { get; set; } = String.Empty;

        [BsonElement("isCorrect")]
        public bool IsCorrect { get; set; }


    }
}
