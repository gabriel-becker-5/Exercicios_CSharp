using System.ComponentModel.DataAnnotations;

namespace Aula_MVC_04_Exercicios.Models
{
    public class Curso
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O Nome do Curso é obrigatório.")]
        [Length(2, 100, ErrorMessage = "O Nome do Curso deve conter no mínimo dois caracteres e no máximo cem caracteres.")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "A Carga Horária é obrigatória.")]
        [Range(1, 500, ErrorMessage = "A Carga Horária mínima permitida é 1 e a máxima 500.")]
        public int CargaHoraria { get; set; }

        public Curso(string nome, int cargahoraria)
        {
            Nome = nome;
            CargaHoraria = cargahoraria;
        }

        public Curso()
        {
            
        }
    }
}