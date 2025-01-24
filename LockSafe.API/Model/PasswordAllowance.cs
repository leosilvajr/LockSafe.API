using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LockSafe.API.Model
{
    public class PasswordAllowance
    {

        [ForeignKey("Password")]
        public int PasswordId { get; set; } //Chave Composta


        [ForeignKey("User")]
        public int UserId { get; set; } //Chave Composta


        [Required]
        public bool IsAdmin { get; set; }
    }
}
