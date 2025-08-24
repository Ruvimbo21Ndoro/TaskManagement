using System.ComponentModel.DataAnnotations;

namespace UsersTasks.DTOs.TaskDTOs
{
    public class AddTaskDTO
    {

        public required string Title { get; set; }

        public required string Description { get; set; }

        public required DateOnly DueDate { get; set; }

        public required Guid Assignee { get; set; }
    }
}
