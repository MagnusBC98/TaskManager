using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using TaskManager.Enums;

namespace TaskManager.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public TaskState Status { get; set; }

        public string? UserId { get; set; }

        public IdentityUser? User { get; set; }
    }
}
