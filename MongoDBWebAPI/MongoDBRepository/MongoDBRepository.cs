using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDBWebAPI.Model;
using System.Threading.Tasks;

namespace MongoDBWebAPI.MongoDBRepository
{
    /// <summary>
    /// Repository class to make Mongo Database calls
    /// </summary>
    public class MongoDBRepository : IMongoDBRepository
    {
        private readonly MongoDatabaseContext mongoDatabaseContext;

        /// <summary>
        /// create mongo database context object
        /// </summary>
        /// <param name="settings"></param>
        public MongoDBRepository(IOptions<Settings> settings)
        {
            mongoDatabaseContext = new MongoDatabaseContext(settings);
        }

        /// <summary>
        /// Create collection in mongo database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task CreateCollectionAsync(string name, CreateCollectionOptions options = null)
        {
            await mongoDatabaseContext.MongoDatabase.CreateCollectionAsync(name, new CreateCollectionOptions
            {
                AutoIndexId = true,
                Capped = true
            });
        }

        /// <summary>
        /// Insert new entity in user collection
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task CreateUserAsync(User user)
        {
            await mongoDatabaseContext.Users.InsertOneAsync(user);
        }

        /// <summary>
        /// Delete collection from mongo database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task DeleteCollectionAsync(string name)
        {
            await mongoDatabaseContext.MongoDatabase.DropCollectionAsync(name);
        }

        /// <summary>
        /// Delete one user information from user collection
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<User> DeleteUserAsync(string userName)
        {
            var filter = Builders<User>.Filter.Where(s => s.UserName == userName);
            return await mongoDatabaseContext.Users.FindOneAndDeleteAsync<User>(filter);
        }

        /// <summary>
        /// Get user details by passing username from user collection
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            var filter = Builders<User>.Filter.Where(s => s.UserName == userName);
            var result = await mongoDatabaseContext.Users.FindAsync<User>(filter);
            return await result.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Update user information for specific user in user collection
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> UpdateUserAsync(User user)
        {
            var filter = Builders<User>.Filter.Where(s => s.UserName == user.UserName);
            return await mongoDatabaseContext.Users.FindOneAndReplaceAsync<User>(filter, user);
        }
    }
}
