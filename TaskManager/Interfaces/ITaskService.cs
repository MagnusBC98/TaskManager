using TaskManager.Models;

namespace TaskManager.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetTasksAsync();
        Task<TaskItem?> GetTaskAsync(int id);
        Task<TaskItem> CreateTaskAsync(TaskItem taskItem);
        Task<bool> UpdateTaskAsync(TaskItem taskItem);
        Task<bool> DeleteTaskAsync(int id);
    }
}
