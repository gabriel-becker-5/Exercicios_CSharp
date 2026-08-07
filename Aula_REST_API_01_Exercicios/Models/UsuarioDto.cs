using System.ComponentModel.DataAnnotations;

namespace Aula_REST_API_01_Exercicios.Models
{
    public class UsuarioDto
    {
        [Required, MinLength(3), MaxLength(200)]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(10), MaxLength(50)]
        public string Senha { get; set; }
    }
}