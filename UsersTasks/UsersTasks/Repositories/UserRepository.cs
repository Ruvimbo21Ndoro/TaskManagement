using UsersTasks.Interfaces.Repositories;
using UsersTasks.Models.Entities;

namespace UsersTasks.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task CreateUserAsync(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserEntity>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> GetUserByIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
