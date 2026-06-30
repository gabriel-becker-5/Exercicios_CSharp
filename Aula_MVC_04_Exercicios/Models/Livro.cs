namespace Aula_MVC_04_Exercicios.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public List<Emprestimo> Emprestimos { get; set; } = new();
    }
}