using UsersTasks.DTOs.TaskDTOs;
using UsersTasks.DTOs.UserDTOs;
using UsersTasks.Models.Entities;

namespace UsersTasks.Interfaces.Services
{
    public interface ITaskService
    {
        Task<List<TaskEntity>> GetAllTasksAsync();

        Task<TaskEntity> GetATaskByIdAsync(Guid taskId);

        Task DeleteATaskByIdAsync(Guid taskId);
        Task UpdateTaskByIdAsync(Guid taskId, TaskEntity newTask);

        Task CreateTaskAsync(AddTaskDTO task);
    }
}
