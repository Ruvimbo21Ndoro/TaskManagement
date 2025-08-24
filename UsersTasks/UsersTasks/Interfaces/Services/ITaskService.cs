using UsersTasks.DTOs.TaskDTOs;
using UsersTasks.DTOs.UserDTOs;
using UsersTasks.Models.Entities;

namespace UsersTasks.Interfaces.Services
{
    public interface ITaskService
    {
        Task<List<FetchTaskDTO>> GetAllTasksAsync();

        Task<FetchTaskDTO> GetATaskByIdAsync(Guid taskId);

        Task<bool> DeleteATaskByIdAsync(Guid taskId);
        Task<bool> UpdateTaskByIdAsync(Guid taskId, UpdateTaskDTO updateUser);

        Task<bool> CreateTaskAsync(AddTaskDTO task);

        Task<List<FetchTaskDTO>> GetExpiredTasksAsync();
        Task<List<FetchTaskDTO>> GetActiveTasksAsync();
        Task<List<FetchTaskDTO>> GetTasksByDateAsync(DateOnly givenDate);
        Task<List<FetchTaskDTO>> GetTasksByAssigneeAsync(Guid assigneeId);
    }
}
