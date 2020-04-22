using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace learn_dotnet.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name {get; set;}

        public string Email {get; set;}

        public string Document {get; set;}
    }
}