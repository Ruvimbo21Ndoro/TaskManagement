using System.ComponentModel.DataAnnotations;

namespace UsersTasks.Models.Entities
{
    public class UserEntity
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
