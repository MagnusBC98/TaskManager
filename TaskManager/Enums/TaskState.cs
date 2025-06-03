using System.ComponentModel.DataAnnotations;

namespace TaskManager.Enums
{
    public enum TaskState
    {
        [Display(Name = "Not Started")]
        NotStarted,

        [Display(Name = "In Progress")]
        InProgress,

        Completed,

        [Display(Name = "On Hold")]
        OnHold,

        Cancelled
    }
}
