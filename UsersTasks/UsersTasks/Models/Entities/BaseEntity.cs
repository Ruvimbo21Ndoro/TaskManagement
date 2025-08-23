using System.ComponentModel.DataAnnotations;

namespace UsersTasks.Models.Entities
{

    //Created a base entity that encapsulate fields that are the same in both entities
    public class BaseEntity 
    {
        [Key]
        public Guid Id { get; set; }

        //Added fields to help us determine when a user was created and updated
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedDate { get; set; }
    }
}
