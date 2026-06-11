namespace Exercicio_Integrador_1
{
    public class BibliotecaService
    {
        public async Task<List<Livro>> ObterLivrosAsync(List<Livro> livros)
        {
            await Task.Delay(1500);
            return livros;
        }

        public async Task SalvarLivroAsync(Livro livro, List<Livro> livros)
        {
            await Task.Delay(1500);
            livros.Add(livro);
        }
    }
}