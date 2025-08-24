using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using UsersTasks.DTOs.TaskDTOs;
using UsersTasks.DTOs.UserDTOs;
using UsersTasks.Interfaces.Repositories;
using UsersTasks.Interfaces.Services;
using UsersTasks.Models.Entities;

namespace UsersTasks.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repo;
        private readonly IUserService _userService;
        public TaskService(ITaskRepository repo, IUserService userService)
        {
            _repo = repo;
            _userService = userService;
        }
        public async Task<bool> CreateTaskAsync(AddTaskDTO task)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(task.Assignee);

                if (user == null)
                    return false;

                var newTask = new TaskEntity
                {
                    Title = task.Title,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    Assignee = task.Assignee,
                };

                await _repo.CreateTaskAsync(newTask);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteATaskByIdAsync(Guid taskId)
        {
            try
            {
                var foundTask = await _repo.GetATaskByIdAsync(taskId);

                if (foundTask == null)
                {
                    return false;
                }

                await _repo.DeleteATaskByIdAsync(foundTask);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FetchTaskDTO>> GetAllTasksAsync()
        {
            return await _repo.GetAllTasksAsync();
        }

        public async Task<FetchTaskDTO> GetATaskByIdAsync(Guid taskId)
        {
            try
            {
                var task = await _repo.GetATaskByIdAsync(taskId);

                if (task == null)
                    return null;



                return new FetchTaskDTO
                {
                    Id = task.Id,
                    CreatedDate = task.CreatedDate,
                    UpdatedDate = task.UpdatedDate,
                    Title = task.Title,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    Assignee = new FetchUserDTO
                    {
                        Id = task.User.Id,
                        Username = task.User.Username,
                        Email = task.User.Email,
                        CreatedDate = task.User.CreatedDate,
                        UpdatedDate = task.User.UpdatedDate
                    }
                };
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<bool> UpdateTaskByIdAsync(Guid taskId, UpdateTaskDTO updateTask)
        {
            try
            {
                var existingUser = await _userService.GetUserByIdAsync(updateTask.Assignee);

                if (existingUser == null)
                    return false;

                var existingTask = await _repo.GetATaskByIdAsync(taskId);

                if(existingTask == null)
                    return false;


                existingTask.Title = updateTask.Title;
                existingTask.Description = updateTask.Description;
                existingTask.DueDate = updateTask.DueDate;
                existingTask.Assignee = updateTask.Assignee;
                existingTask.UpdatedDate = DateTime.Now;
               

                await _repo.UpdateTaskByIdAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FetchTaskDTO>> GetExpiredTasksAsync()
        {
            return await _repo.GetExpiredTasksAsync();
        }

        public async Task<List<FetchTaskDTO>> GetActiveTasksAsync()
        {
            return await _repo.GetActiveTasksAsync();
        }

        public async Task<List<FetchTaskDTO>> GetTasksByDateAsync(DateOnly givenDate)
        {
            return await _repo.GetTasksByDateAsync(givenDate);
        }

        public async Task<List<FetchTaskDTO>> GetTasksByAssigneeAsync(Guid assigneeId)
        {
            return await _repo.GetTasksByAssigneeAsync(assigneeId);
        }
    }
}
