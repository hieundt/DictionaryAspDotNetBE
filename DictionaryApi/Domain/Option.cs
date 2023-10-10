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
        [JsonPropertyName("value")]
        private string _value = null!;

        [BsonElement("isCorrect")]
        [JsonPropertyName("isCorrect")]
        private bool _isCorrect;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public bool IsCorrect
        {
            get { return _isCorrect; }
            set { _isCorrect = value; }
        }
    }
}
