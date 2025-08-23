using UsersTasks.Models.Entities;

namespace UsersTasks.Interfaces.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskEntity>> GetAllTasksAsync();

        Task<TaskEntity> GetATaskByIdAsync(Guid taskId);

        Task DeleteATaskByIdAsync(Guid taskId);
        Task UpdateTaskByIdAsync(Guid taskId, TaskEntity newTask);

        Task CreateTaskAsync(TaskEntity user);
    }
}
