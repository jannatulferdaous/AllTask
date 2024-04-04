using REST_API.Models;
using REST_API.Response;

namespace REST_API.Services
{
    public interface IUserService
    {
        Task<PagedResponse<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(int id, User user);
        Task<User> CreateUser(User user);
        Task DeleteUser(int id);
    }
}
