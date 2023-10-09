using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using DictionaryApi.DataAccess.CollectionNaming;

namespace DictionaryApi.Domain
{
    [BsonCollection("unit")]
    public class Unit : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        [JsonPropertyName("name")]
        private string _name = String.Empty;

        [BsonElement("image")]
        [JsonPropertyName("image")]
        private string _image = String.Empty;

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
    }
}
