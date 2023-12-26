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
        public bool? Type { get; set; }

        [BsonElement("title")]
        public string Title { get; set; } = String.Empty;

        [BsonElement("description")]
        public string Description { get; set; } = String.Empty;

        [BsonElement("answer")]
        public string Answer { get; set; } = String.Empty;

        [BsonElement("point")]
        public int? Point { get; set; } = 0;

        [BsonElement("options")]
        public List<string> Options { get; set; } = new List<string>();

    }
}
