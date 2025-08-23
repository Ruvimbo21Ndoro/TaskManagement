using UsersTasks.Interfaces.Repositories;
using UsersTasks.Models.Entities;

namespace UsersTasks.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public Task CreateTaskAsync(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteATaskByIdAsync(Guid taskId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TaskEntity>> GetAllTasksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TaskEntity> GetATaskByIdAsync(Guid taskId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTaskByIdAsync(Guid taskId, TaskEntity newTask)
        {
            throw new NotImplementedException();
        }
    }
}
