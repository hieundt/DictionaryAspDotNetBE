using System.Security.Cryptography;
using System.Text.Json.Serialization;
using DictionaryApi.DataAccess.CollectionNaming;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DictionaryApi.Domain
{
    [BsonCollection("vocabulary")]
    public class Vocabulary : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("type")]
        public string Type { get; set; } = string.Empty;

        [BsonElement("word")]
        public string Word { get; set; } = string.Empty;

        [BsonElement("hint")]
        public string Hint { get; set; } = string.Empty;

        [BsonElement("phonetics")]
        public string Phonetics { get; set; } = string.Empty;

        [BsonElement("pronouce")]
        public string Pronouce { get; set; } = string.Empty;

        [BsonElement("image")]
        public string Image { get; set; } = string.Empty;

        [BsonElement("meaning")]
        public string Meaning { get; set; } = string.Empty;
 
    }
}
