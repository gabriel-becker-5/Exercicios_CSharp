using System.ComponentModel.DataAnnotations;

namespace Aula_REST_API_01_Exercicios.Models
{
    public class Produto
    {
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; }
        
        [Required]
        public decimal Preco { get; set; }

        [Required, EmailAddress]
        public string EmailFornecedor { get; set; }
    }
}