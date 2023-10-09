using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using DictionaryApi.DataAccess.CollectionNaming;

namespace DictionaryApi.Domain
{
    [BsonCollection("favoriteunit")]
    public class FavoriteUnit : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("userId")]
        [JsonPropertyName("userId")]
        private string _userId = String.Empty;

        [BsonElement("unitId")]
        [JsonPropertyName("unitId")]
        private string _unitId = String.Empty;

        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public string UnitId
        {
            get { return _unitId; }
            set { _unitId = value; }
        }
    }
}
