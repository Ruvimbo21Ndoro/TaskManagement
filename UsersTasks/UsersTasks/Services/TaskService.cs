using UsersTasks.Interfaces.Services;
using UsersTasks.Models.Entities;

namespace UsersTasks.Services
{
    public class TaskService : ITaskService
    {
        public Task CreateTaskAsync(TaskEntity user)
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
