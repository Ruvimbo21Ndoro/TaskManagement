using System.ComponentModel.DataAnnotations;

namespace UsersTasks.DTOs.TaskDTOs
{
    public class AddTaskDTO
    {

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Due date is required")]
        public DateOnly DueDate { get; set; }

        [Required(ErrorMessage = "Assignee is required")]
        public Guid Assignee { get; set; }
    }
}
