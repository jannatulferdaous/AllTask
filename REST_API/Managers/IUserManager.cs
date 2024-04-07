using REST_API.Models;
using REST_API.Response;

namespace REST_API.Managers
{
    public interface IUserManager
    {
        Task<PagedResponse<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(int id, User user);
        Task<User> CreateUser(User user);
        Task<User> ValidUser(Login login);
        Task DeleteUser(int id);
    }
}
