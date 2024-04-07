using REST_API.Models;
using REST_API.Response;
using REST_API.Services;

namespace REST_API.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserService _service;
        public UserManager(IUserService service)
        {
            _service = service;
        }
        public async Task<User> CreateUser(User user)
        {
            return await _service.CreateUser(user);
        }

        public async Task DeleteUser(int id)
        {
            await _service.DeleteUser(id);
        }

        public async Task<PagedResponse<User>> GetAllUsers()
        {
             return await _service.GetAllUsers();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _service.GetUserById(id);
        }

        public async Task<User> UpdateUser(int id, User user)
        {
             return await _service.UpdateUser(id, user);
        }

        public async Task<User> ValidUser(Login login)
        {
            return await _service.ValidUser(login);
        }
    }
}
