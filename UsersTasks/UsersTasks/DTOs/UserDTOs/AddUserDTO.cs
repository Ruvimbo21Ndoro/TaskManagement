using System.ComponentModel.DataAnnotations;

namespace UsersTasks.DTOs.UserDTOs
{
    public class AddUserDTO
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
