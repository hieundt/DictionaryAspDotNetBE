using System.Text.Json.Serialization;
using DictionaryApi.DataAccess.CollectionNaming;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DictionaryApi.Domain
{

    [BsonCollection("question")]
    public class Question : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("type")]
        [JsonPropertyName("type")]
        private bool? _type;

        [BsonElement("title")]
        [JsonPropertyName("title")]
        private string _title = String.Empty;

        [BsonElement("description")]
        [JsonPropertyName("description")]
        private string _description = String.Empty;

        [BsonElement("answer")]
        [JsonPropertyName("answer")]
        private string _answer = String.Empty;

        [BsonElement("point")]
        [JsonPropertyName("point")]
        private int? _point;

        [BsonElement("options")]
        [JsonPropertyName("options")]
        private List<string> _options = new List<string>();

        public bool? Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Answer
        {
            get { return _answer; }
            set { _answer = value; }
        }
        public int? Point
        {
            get { return _point; }
            set { _point = value; }
        }
        public List<string> Options
        {
            get { return _options; }
            set { _options = value; }
        }
    }
}
