using System.ComponentModel.DataAnnotations;

namespace Aula_REST_API_01_Exercicios.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        
        [Required, MinLength(3), MaxLength(200)]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string SenhaHash { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}