using System.ComponentModel.DataAnnotations;

namespace UsersTasks.DTOs.UserDTOs
{
    public class AddUserDTO
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
