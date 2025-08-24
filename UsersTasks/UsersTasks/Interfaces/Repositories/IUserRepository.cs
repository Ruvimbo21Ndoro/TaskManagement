using UsersTasks.DTOs.UserDTOs;
using UsersTasks.Models.Entities;

namespace UsersTasks.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task CreateUserAsync(UserEntity user);

        Task<UserEntity> GetUserByIdAsync(Guid userId);

        Task<List<FetchUserDTO>> GetAllUsersAsync();

        Task UpdateUserAsync(UserEntity userId);

        Task DeleteUserAsync(UserEntity userId);

        Task<FetchUserDTO> GetUserByEmailAsync(string email);
    }
}
