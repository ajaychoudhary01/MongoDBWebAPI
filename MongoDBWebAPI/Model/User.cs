using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBWebAPI.Model
{
    /// <summary>
    /// Mongo database entity model
    /// </summary>
    public class User
    {
        [BsonId]
        public ObjectId _id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public string DateOfBirth { get; set; }

        public string Street { get; set; }

        public string PostCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
