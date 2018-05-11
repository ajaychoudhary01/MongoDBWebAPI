using Microsoft.AspNetCore.Mvc;
using MongoDBWebAPI.Model;
using MongoDBWebAPI.MongoDBRepository;
using System.Threading.Tasks;

namespace MongoDBWebAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    public class MongoController : Controller
    {
        private readonly IMongoDBRepository mongoDBRepository;
        
        /// <summary>
        /// Injected mongo database repository dependency
        /// </summary>
        /// <param name="mongoDBRepository"></param>
        public MongoController(IMongoDBRepository mongoDBRepository)
        {
            this.mongoDBRepository = mongoDBRepository;
        }

        /// <summary>
        /// Create Collection in mongo database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task CreateCollectionAsync(string name)
        {
            await mongoDBRepository.CreateCollectionAsync(name);
        }

        /// <summary>
        /// Get User information by user name from mongo database
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            return await mongoDBRepository.GetUserByUserNameAsync(userName);
        }
        
        /// <summary>
        /// Update user information in mongo database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<User> UpdateUserAsync(User user)
        {
            return await mongoDBRepository.UpdateUserAsync(user);
        }

        /// <summary>
        /// Create new user in mongo database user collection
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task CreateUserAsync(User user)
        {
            await mongoDBRepository.CreateUserAsync(user);
        }
        
        /// <summary>
        /// delete one user in mongo database user collection
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<User> DeleteUserAsync(string userName)
        {
            return await mongoDBRepository.DeleteUserAsync(userName);
        }

        /// <summary>
        /// Delete collection from mongo database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task DeleteCollectionAsync(string name)
        {
            await mongoDBRepository.DeleteCollectionAsync(name);
        }
    }
}
