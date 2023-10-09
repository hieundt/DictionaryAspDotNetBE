using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using DictionaryApi.DataAccess.CollectionNaming;

namespace DictionaryApi.Domain
{
    [BsonCollection("unithasvocabulary")]
    public class UnitHasVocabulary : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("unitId")]
        [JsonPropertyName("unitId")]
        private string _unitId = String.Empty;

        [BsonElement("vocabularyId")]
        [JsonPropertyName("vocabularyId")]
        private string _vocabularyId = String.Empty;

        public string UnitId
        {
            get { return _unitId; }
            set { _unitId = value; }
        }
        public string VocabularyId
        {
            get { return _vocabularyId; }
            set { _vocabularyId = value; }
        }
    }
}
