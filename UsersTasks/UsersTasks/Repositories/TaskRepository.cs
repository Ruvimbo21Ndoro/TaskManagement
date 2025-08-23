using Microsoft.EntityFrameworkCore;
using UsersTasks.Data.DBContext;
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

        public async Task<List<TaskEntity>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskEntity> GetATaskByIdAsync(Guid taskId)
        {
            return await _context.Tasks.FindAsync(taskId);
        }

        public async Task UpdateTaskByIdAsync(Guid taskId, TaskEntity newTask)
        {
            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.Assignee = updatedTask.Assignee;
            task.DueDate = updatedTask.DueDate;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
