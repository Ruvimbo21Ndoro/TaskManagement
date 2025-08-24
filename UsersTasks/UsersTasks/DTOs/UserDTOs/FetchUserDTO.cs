using System.ComponentModel.DataAnnotations;

namespace UsersTasks.DTOs.UserDTOs
{
    public class FetchUserDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; }
    }
}
