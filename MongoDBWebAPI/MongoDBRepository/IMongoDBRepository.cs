using MongoDB.Driver;
using MongoDBWebAPI.Model;
using System.Threading.Tasks;

namespace MongoDBWebAPI.MongoDBRepository
{
    /// <summary>
    /// interface for mongo database repository
    /// </summary>
    public interface IMongoDBRepository
    {
        /// <summary>
        /// Create collection in mongo database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Task CreateCollectionAsync(string name,  CreateCollectionOptions options = null);

        /// <summary>
        /// Get user details by passing username from user collection
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<User> GetUserByUserNameAsync(string userName);

        /// <summary>
        /// Update user information for specific user in user collection
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> UpdateUserAsync(User user);

        /// <summary>
        /// Insert new entity in user collection
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task CreateUserAsync(User user);

        /// <summary>
        /// Delete one user information from user collection
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<User> DeleteUserAsync(string userName);

        /// <summary>
        /// Delete collection from mongo database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task DeleteCollectionAsync(string name);
    }
}
