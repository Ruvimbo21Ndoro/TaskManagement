using System.ComponentModel.DataAnnotations;

namespace UsersTasks.Models.Entities
{
    public class TaskEntity : BaseEntity
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title must not exceed 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description must not exceed 500 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Due date is required")]
        public DateOnly DueDate { get; set; }

        [Required(ErrorMessage = "Assignee is required")]
        public Guid Assignee { get; set; }
        public UserEntity? User { get; set; } // Navigation property to the UserEntity

    }
}
