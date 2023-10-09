using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using DictionaryApi.DataAccess.CollectionNaming;

namespace DictionaryApi.Domain
{
    [BsonCollection("favoritevocabulary")]
    public class FavoriteVocabulary : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("userId")]
        [JsonPropertyName("userId")]
        private string _userId = String.Empty;

        [BsonElement("vocabularyId")]
        [JsonPropertyName("vocabularyId")]
        private string _vocabularyId = String.Empty;

        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public string VocabularyId
        {
            get { return _vocabularyId; }
            set { _vocabularyId = value; }
        }
    }
}
