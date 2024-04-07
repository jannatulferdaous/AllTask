using Microsoft.EntityFrameworkCore;
using REST_API.DataLayer;
using REST_API.Models;
using REST_API.Response;

namespace REST_API.Services
{
    public class UserService : IUserService
    {
        public readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            if (user is not null)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();              
            }
            return user;

        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
            {
                return;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResponse<User>> GetAllUsers()
        {
            IEnumerable<User> user = [];

            user = await _context.Users.ToListAsync();

            if (user is null || user.Count() <= 0)
            {

                return new PagedResponse<User>
                {
                    Data = [],
                    TotalCount = 0,
                    IsSuccess = user is null ? false : true,
                    Message = "No user Found"
                };
            }

            return new PagedResponse<User>
            {
                Data = user,
                TotalCount = user.Count(),
                IsSuccess = true,
                Message = string.Empty
            };
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user is null ? null : user;
        }

        public async Task<User> UpdateUser(int id, User user)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser is null)
            {
                return null;

            }
            existingUser.Name = user.Name;
            existingUser.Password = user.Password;
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<User> ValidUser(Login login)
        {
           var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == login.Name && u.Password==login.Password);
          if (user is null)
            {
             return null;
            }
          return user;
             
        }
    }
}
