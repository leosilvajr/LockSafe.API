using System.ComponentModel.DataAnnotations;

namespace LockSafe.API.Model
{
    public class Password
    {
        [Key]
        public int Id { get; set; } //Campo automatico (Auto gerado)

        [Required]
        [MaxLength(255)]
        public string Title { get; set; } //DTO

        public string Description { get; set; }

        public string Reference { get; set; }

        [Required]
        [MaxLength(255)]
        public string Account { get; set; }

        [Required]
        public string PasswordValue { get; set; } 

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now; //Campo automatico com a data atual

        //ExpirationDate será 1 ano apos a data de criacao
        public DateTime? ExpirationDate { get; set; } = DateTime.Now.AddYears(1);
        //Sugestão automatica porem o usuario pode alterar

    }
}
