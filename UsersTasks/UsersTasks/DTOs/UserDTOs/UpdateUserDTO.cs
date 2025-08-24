using System.ComponentModel.DataAnnotations;

namespace UsersTasks.DTOs.UserDTOs
{
    public class UpdateUserDTO
    {
        public Guid Id { get; set; }
       
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
