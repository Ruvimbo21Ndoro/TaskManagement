using UsersTasks.DTOs;
using UsersTasks.Models.Entities;

namespace UsersTasks.Interfaces.Services
{
    public interface ITaskService
    {
        Task<List<TaskEntity>> GetAllTasksAsync();

        Task<TaskEntity> GetATaskByIdAsync(Guid taskId);

        Task DeleteATaskByIdAsync(Guid taskId);
        Task UpdateTaskByIdAsync(Guid taskId, TaskEntity newTask);

        Task CreateTaskAsync(AddTaskDTO user);
    }
}
