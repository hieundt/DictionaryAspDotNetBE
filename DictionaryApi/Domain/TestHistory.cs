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
        [JsonPropertyName("userId")]
        private string _userId = String.Empty;

        [BsonElement("testId")]
        [JsonPropertyName("testId")]
        private string _testId = String.Empty;

        [BsonElement("totalPoint")]
        [JsonPropertyName("totalPoint")]
        private int _totalPoint = 0;

        [BsonElement("testDate")]
        [JsonPropertyName("testDate")]
        private DateTime _testDate = DateTime.Now;

        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }    
        }
        public string TestId
        {
            get { return _testId; }
            set { _testId = value; }
        }
        public int TotalPoint
        {
            get { return _totalPoint; }
            set { _totalPoint = value; }
        }
        public DateTime TestDate
        {
            get { return _testDate; }
            set { _testDate = value; }
        }
    }
}
