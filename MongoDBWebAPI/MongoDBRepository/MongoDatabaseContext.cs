using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDBWebAPI.Model;

namespace MongoDBWebAPI.MongoDBRepository
{
    /// <summary>
    /// Mongo database context for accessing collections
    /// </summary>
    public class MongoDatabaseContext
    {
        /// <summary>
        /// create mongo database client <see langword="object"/>
        /// </summary>
        /// <param name="settings"></param>
        public MongoDatabaseContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            MongoDatabase = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<User> Users { get { return MongoDatabase.GetCollection<User>("user"); } }

        public IMongoDatabase MongoDatabase { get; }
    }
}
