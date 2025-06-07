using Microsoft.EntityFrameworkCore;
using System.Net;
using TaskManager.Data;
using TaskManager.Interfaces;
using TaskManager.Models;
using System.Web.Http;

namespace TaskManager.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItem> CreateTaskAsync(TaskItem taskItem)
        {
            _context.Task.Add(taskItem);
            await _context.SaveChangesAsync();
            return taskItem;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var taskItem = await _context.Task.FindAsync(id);
            if (taskItem == null) return false;

            _context.Task.Remove(taskItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TaskItem?> GetTaskAsync(int id)
        {
            return await _context.Task.FindAsync(id);
        }

        public async Task<IEnumerable<TaskItem>> GetTasksAsync()
        {
            return await _context.Task.ToListAsync();
        }

        public async Task<bool> UpdateTaskAsync(TaskItem taskItem)
        {
            if (!_context.Task.Any(t => t.Id == taskItem.Id))
            {
                return false;
            }
            _context.Entry(taskItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
