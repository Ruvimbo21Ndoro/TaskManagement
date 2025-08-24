using UsersTasks.DTOs.UserDTOs;
using UsersTasks.Models.Entities;

namespace UsersTasks.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(AddUserDTO user);

        Task<UserEntity> GetUserByIdAsync(Guid userId);

        Task<List<UserEntity>> GetAllUsersAsync();

        Task<bool> UpdateUserAsync(UpdateUserDTO user);

        Task<bool> DeleteUserAsync(Guid userId);

        Task<FetchUserDTO> GetUserByEmail(string email);
    }
}
