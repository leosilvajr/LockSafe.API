using System.ComponentModel.DataAnnotations;

namespace LockSafe.API.Model
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(255)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; } 

        public string ProfileImageUrl { get; set; }

    }
}
