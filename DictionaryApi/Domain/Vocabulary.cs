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
        public string Id { get; set; } = String.Empty;

        [BsonElement("type")]
        [JsonPropertyName("type")]
        private string _type = String.Empty;

        [BsonElement("word")]
        [JsonPropertyName("word")]
        private string _word = String.Empty;

        [BsonElement("hint")]
        [JsonPropertyName("hint")]
        private string _hint = String.Empty;

        [BsonElement("phonetics")]
        [JsonPropertyName("phonetics")]
        private string _phonetics = String.Empty;

        [BsonElement("pronouce")]
        [JsonPropertyName("pronouce")]
        private string _pronouce = String.Empty;

        [BsonElement("image")]
        [JsonPropertyName("image")]
        private string _image = String.Empty;

        [BsonElement("meaning")]
        [JsonPropertyName("meaning")]
        private string _meaning = String.Empty;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string Word
        {
            get { return _word; }
            set { _word = value; }
        }
        public string Hint
        {
            get { return _hint; }
            set { _hint = value; }
        }
        public string Phonetics
        {
            get { return _phonetics; }
            set { _phonetics = value; }
        }
        public string Pronouce
        {
            get { return _pronouce; }
            set { _pronouce = value; }
        }
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
        public string Meaning
        {
            get { return _meaning; }
            set { _meaning = value; }
        }
    }
}
