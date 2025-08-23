using System.ComponentModel.DataAnnotations;

namespace UsersTasks.Models.Entities
{
    public class TaskEntity : BaseEntity
    {
        [Required]
        public string  Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateOnly DueDate { get; set; }

        [Required]
        public Guid Assignee { get; set; }
        public UserEntity? User { get; set; } // Navigation property to the UserEntity

    }
}
