using System.ComponentModel.DataAnnotations;
using UsersTasks.DTOs.UserDTOs;
using UsersTasks.Models.Entities;

namespace UsersTasks.DTOs.TaskDTOs
{
    public class FetchTaskDTO
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
        public string Title { get; set; }
       
        public string Description { get; set; }
        public DateOnly DueDate { get; set; }
        public FetchUserDTO Assignee { get; set; }
    }
}
