using System.ComponentModel.DataAnnotations;

namespace Aula_REST_API_01_Exercicios.Models
{
    public class UsuarioUpdateDto
    {
        [Required, MinLength(3), MaxLength(200)]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
    }
}