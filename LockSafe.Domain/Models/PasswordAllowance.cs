using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LockSafe.Domain.Models
{
    public class PasswordAllowance
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Password")] // Define a relação com a tabela Password
        public int PasswordId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Users")] // Define a relação com a tabela Users
        public int UserId { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        // Relacionamentos de navegação
        public virtual Password Password { get; set; } // Facilita acesso aos dados relacionados
        public virtual Users Users { get; set; }
    }
}
