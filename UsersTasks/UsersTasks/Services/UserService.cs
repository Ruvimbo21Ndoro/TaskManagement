using UsersTasks.DTOs.UserDTOs;
using UsersTasks.Interfaces.Repositories;
using UsersTasks.Interfaces.Services;
using UsersTasks.Models.Entities;

namespace UsersTasks.Services
{
    public class UserService : IUserService
    {
        IUserRepository _repo;
        public UserService(IUserRepository repo) { 
            _repo = repo;
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
                    Password = user.Password,
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

        public async Task<FetchUserDTO> GetUserByEmail(string email)
        {
            return await _repo.GetUserByEmailAsync(email);
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

        public async Task<bool> UpdateUserAsync(UpdateUserDTO user)
        {
            try
            {
                var existingUser = await _repo.GetUserByIdAsync(user.Id);

                if (existingUser == null)
                {
                    return false;
                }

                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                existingUser.Email = user.Email;

                await _repo.UpdateUserAsync(existingUser);
                return true;
            }
            catch (Exception) {
                throw;
            }
            
        }
    }
}
