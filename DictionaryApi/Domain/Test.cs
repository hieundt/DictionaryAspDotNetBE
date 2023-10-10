using DictionaryApi.DataAccess.CollectionNaming;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace DictionaryApi.Domain
{
    [BsonCollection("test")]
    public class Test : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        [JsonPropertyName("name")]
        private string _name = string.Empty;

        [BsonElement("image")]
        [JsonPropertyName("image")]
        private string _image = String.Empty;

        [BsonElement("questions")]
        [JsonPropertyName("questions")]
        private List<string> _questions = new List<string>();

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
        public List<string> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }
    }
}
