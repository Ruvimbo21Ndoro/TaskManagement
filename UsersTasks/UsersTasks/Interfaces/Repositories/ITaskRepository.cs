using UsersTasks.Models.Entities;

namespace UsersTasks.Interfaces.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskEntity>> GetAllTasksAsync();

        Task<TaskEntity> GetATaskByIdAsync(Guid taskId);

        Task DeleteATaskByIdAsync(TaskEntity task);
        Task UpdateTaskByIdAsync();

        Task CreateTaskAsync(TaskEntity task);
    }
}
