using UsersTasks.Models.Entities;

namespace UsersTasks.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task CreateUserAsync(UserEntity user);

        Task<UserEntity> GetUserByIdAsync(Guid userId);

        Task<List<UserEntity>> GetAllUsersAsync();

        Task UpdateUserAsync(Guid userId);

        Task DeleteUserAsync(Guid userId);
    }
}
