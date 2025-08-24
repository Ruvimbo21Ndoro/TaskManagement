using Microsoft.EntityFrameworkCore;
using UsersTasks.Data.DBContext;
using UsersTasks.DTOs.UserDTOs;
using UsersTasks.Interfaces.Repositories;
using UsersTasks.Models.Entities;

namespace UsersTasks.Repositories
{
    public class UserRepository : IUserRepository
    {
        TaskContext _context;
        public UserRepository(TaskContext context) { 
            _context = context;
        }
        public async Task CreateUserAsync(UserEntity user)
        {
           await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(UserEntity user)
        {
             _context.Users.Remove(user);
             await _context.SaveChangesAsync();
        }

        public async Task<List<UserEntity>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<FetchUserDTO> GetUserByEmailAsync(string email)
        {
            return await _context.Users.Where(user => user.Email.Equals(email)).Select(user => new FetchUserDTO { 
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                CreatedDate = user.CreatedDate,
                UpdatedDate = user.UpdatedDate

            }).FirstOrDefaultAsync();
        }

        public async Task<UserEntity> GetUserByIdAsync(Guid userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task UpdateUserAsync(UserEntity user)
        {
            await _context.SaveChangesAsync();
        }
    }
}
