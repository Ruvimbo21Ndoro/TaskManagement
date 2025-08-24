using UsersTasks.DTOs.TaskDTOs;
using UsersTasks.Models.Entities;

namespace UsersTasks.Interfaces.Repositories
{
    public interface ITaskRepository
    {
        Task<List<FetchTaskDTO>> GetAllTasksAsync();

        Task<TaskEntity> GetATaskByIdAsync(Guid taskId);

        Task DeleteATaskByIdAsync(TaskEntity task);
        Task UpdateTaskByIdAsync();

        Task<List<FetchTaskDTO>> GetExpiredTasksAsync();
        Task<List<FetchTaskDTO>> GetActiveTasksAsync();
        Task<List<FetchTaskDTO>> GetTasksByDateAsync(DateOnly givenDate);
        Task<List<FetchTaskDTO>> GetTasksByAssigneeAsync(Guid assigneeId);

        Task CreateTaskAsync(TaskEntity task);
    }
}
