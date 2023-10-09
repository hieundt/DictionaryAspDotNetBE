using System.Text.Json.Serialization;
using DictionaryApi.DataAccess.CollectionNaming;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DictionaryApi.Domain
{
    [BsonCollection("user")]
    public class User : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("email")]
        [JsonPropertyName("email")]
        private string _email = String.Empty;

        [BsonElement("password")]
        [JsonPropertyName("password")]
        private string _password = String.Empty;

        [BsonElement("userName")]
        [JsonPropertyName("userName")]
        private string _userName = String.Empty;

        [BsonElement("dateOfBirth")]
        [JsonPropertyName("dateOfBirth")]
        private DateTime? _dateOfBirth;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string PassWord
        {
            get { return _password; }
            set { _password = value; }
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public DateTime? DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }
    }
}
