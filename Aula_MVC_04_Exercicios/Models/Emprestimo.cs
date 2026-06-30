namespace Aula_MVC_04_Exercicios.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public DateOnly DataEmprestimo { get; set; }
        public DateOnly DataDevolucao { get; set; }
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
    }
}