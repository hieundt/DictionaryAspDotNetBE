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
        public string UnitId { get; set; } = String.Empty;

        [BsonElement("vocabularyId")]
        public string VocabularyId { get; set; } = String.Empty;

    }
}
