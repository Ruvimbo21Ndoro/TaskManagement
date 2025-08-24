using Microsoft.EntityFrameworkCore;
using UsersTasks.Data.DBContext;
using UsersTasks.DTOs.TaskDTOs;
using UsersTasks.DTOs.UserDTOs;
using UsersTasks.Interfaces.Repositories;
using UsersTasks.Models.Entities;

namespace UsersTasks.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext _context;

        public TaskRepository(TaskContext context) {
            _context = context;
        }

        public async Task CreateTaskAsync(TaskEntity task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteATaskByIdAsync(TaskEntity task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task<TaskEntity> GetATaskByIdAsync(Guid taskId)
        {
            return await _context.Tasks.Include(ta => ta.User).FirstOrDefaultAsync(task => task.Id == taskId);
        }

        public async Task UpdateTaskByIdAsync()
        {
             await _context.SaveChangesAsync();
        }

        public async Task<List<FetchTaskDTO>> GetAllTasksAsync()
        {
            return await ProjectToFetchTaskDTO(
                _context.Tasks.OrderByDescending(task => task.CreatedDate)
            ).ToListAsync();
        }

        public async Task<List<FetchTaskDTO>> GetExpiredTasksAsync()
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            return await ProjectToFetchTaskDTO(
                _context.Tasks.Where(task => task.DueDate < today)
                              .OrderByDescending(task => task.CreatedDate)
            ).ToListAsync();
        }

        public async Task<List<FetchTaskDTO>> GetActiveTasksAsync()
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            return await ProjectToFetchTaskDTO(
                _context.Tasks.Where(task => task.DueDate >= today)
                              .OrderByDescending(task => task.CreatedDate)
            ).ToListAsync();
        }

        public async Task<List<FetchTaskDTO>> GetTasksByDateAsync(DateOnly givenDate)
        {
            return await ProjectToFetchTaskDTO(
                _context.Tasks.Where(task => task.DueDate == givenDate)
                              .OrderByDescending(task => task.CreatedDate)
            ).ToListAsync();
        }

        public async Task<List<FetchTaskDTO>> GetTasksByAssigneeAsync(Guid assigneeId)
        {
            return await ProjectToFetchTaskDTO(
                _context.Tasks.Where(task => task.Assignee == assigneeId)
                              .OrderByDescending(task => task.CreatedDate)
            ).ToListAsync();
        }

        //This is a helper method that contains the logic to project the entity to the DTO,
        //so that I do not do it redundantly in each method
        private IQueryable<FetchTaskDTO> ProjectToFetchTaskDTO(IQueryable<TaskEntity> query)
        {
            return query.Select(task => new FetchTaskDTO
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
            });
        }

    }
}
