using System.ComponentModel.DataAnnotations;

namespace Aula_MVC_04_Exercicios.Models
{
    public class Aluno
    {
        public int Id { get;  set; }

        [Required(ErrorMessage = "O preenchimento do nome é obrigatório.")]
        [Length(3, 100, ErrorMessage = "O nome deve ter no mínimo três caracteres e no máximo cem caracteres.")]
        public string Nome { get;  set; }

        [Required(ErrorMessage = "O preenchimento do e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido.")]
        public string Email { get;  set; }

        [Required(ErrorMessage = "Data Nascimento informada é inválida.")]
        public DateTime DataNascimento { get;  set; }
        public string Telefone { get;  set; }

        public Aluno(string nome, string email, DateTime datanascimento, string telefone)
        {
            Nome = nome;
            Email = email;
            DataNascimento = datanascimento;
            Telefone = telefone;
        }

        public Aluno()
        {
        }
    }
}