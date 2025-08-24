using UsersTasks.DTOs.UserDTOs;
using UsersTasks.Interfaces.Repositories;
using UsersTasks.Interfaces.Services;
using UsersTasks.Models.Entities;
using UsersTasks.Utilities;

namespace UsersTasks.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        private readonly IEncryptionService _encryptionService;
        public UserService(IUserRepository repo, IEncryptionService encryptionService) { 
            _repo = repo;
            _encryptionService = encryptionService;
        }
        public async Task<bool> CreateUserAsync(AddUserDTO user)
        {
            try
            {
                var existingUser = await _repo.GetUserByEmailAsync(user.Email);

                if (existingUser != null)
                {
                    return false;
                }

                var newUser = new UserEntity
                {
                    Email = user.Email,
                    Username = user.Username,
                    Password = _encryptionService.HashPassword(user.Password),
                };

                await _repo.CreateUserAsync(newUser);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            try
            {
                var existingUser = await _repo.GetUserByIdAsync(userId);

                if (existingUser == null)
                {
                    return false;
                }

                await _repo.DeleteUserAsync(existingUser);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<List<FetchUserDTO>> GetAllUsersAsync()
        {
            try
            {
                return await _repo.GetAllUsersAsync();
            }
            catch (Exception) {
                throw;
            }
            
        }

        public async Task<FetchUserDTO?> GetUserByIdAsync(Guid userId)
        {
            try
            {
                var user = await _repo.GetUserByIdAsync(userId);

                if (user == null)
                    return null;


                return new FetchUserDTO
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    CreatedDate = user.CreatedDate,
                    UpdatedDate = user.UpdatedDate,
                };
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<bool> UpdateUserAsync(Guid userId, UpdateUserDTO user)
        {
            try
            {
                var existingUser = await _repo.GetUserByIdAsync(userId);

                if (existingUser == null)
                {
                    return false;
                }

                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                existingUser.Email = user.Email;
                existingUser.UpdatedDate = DateTime.Now;

                await _repo.UpdateUserAsync(existingUser);
                return true;
            }
            catch (Exception) {
                throw;
            }
            
        }
    }
}
