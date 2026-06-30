namespace Aula_MVC_04_Exercicios.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Telefone { get; set; }
    }
}