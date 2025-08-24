using UsersTasks.DTOs.TaskDTOs;
using UsersTasks.DTOs.UserDTOs;
using UsersTasks.Models.Entities;

namespace UsersTasks.Interfaces.Services
{
    public interface ITaskService
    {
        Task<List<TaskEntity>> GetAllTasksAsync();

        Task<TaskEntity> GetATaskByIdAsync(Guid taskId);

        Task<bool> DeleteATaskByIdAsync(Guid taskId);
        Task<bool> UpdateTaskByIdAsync(Guid taskId, UpdateTaskDTO updateUser);

        Task<bool> CreateTaskAsync(AddTaskDTO task);
    }
}
