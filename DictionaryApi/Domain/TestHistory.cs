using System.Text.Json.Serialization;
using DictionaryApi.DataAccess.CollectionNaming;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DictionaryApi.Domain
{
    [BsonCollection("testhistory")]
    public class TestHistory : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("userId")]
        public string UserId { get; set; } = String.Empty;

        [BsonElement("testId")]
        public string TestId { get; set; } = String.Empty;

        [BsonElement("totalPoint")]
        public int TotalPoint { get; set; } = 0;

        [BsonElement("testDate")]
        public DateTime TestDate { get; set; } = DateTime.Now;

    }
}
