using UsersTasks.DTOs.TaskDTOs;
using UsersTasks.DTOs.UserDTOs;
using UsersTasks.Interfaces.Repositories;
using UsersTasks.Interfaces.Services;
using UsersTasks.Models.Entities;

namespace UsersTasks.Services
{
    public class TaskService : ITaskService
    {
        ITaskRepository _repo;
        public TaskService(ITaskRepository repo) {
            _repo = repo;
        }
        public async Task CreateTaskAsync(AddTaskDTO task)
        {
            //Get data from frontend

            // USerID .....

            //Find if the assigned person id exists

            //await _repo.CreateTaskAsync();
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
