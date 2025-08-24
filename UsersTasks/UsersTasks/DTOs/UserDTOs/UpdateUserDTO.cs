using System.ComponentModel.DataAnnotations;

namespace UsersTasks.DTOs.UserDTOs
{
    public class UpdateUserDTO
    {

        [StringLength(50)]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }
    }
}
