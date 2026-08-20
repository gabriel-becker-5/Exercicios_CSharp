using Aula_REST_API_01_Exercicios.Models;

namespace Aula_REST_API_01_Exercicios.Interfaces
{
    public interface IProdutoRepository
    {

        public Task<List<Produto>> GetTodosAsync();

        public Task<Produto?> GetPorIdAsync(int id);

        public Task<Produto> CriarAsync(Produto produto);

        public Task AtualizarAsync(Produto produto);

        public Task DeletarAsync(Produto produto);

        public Task<List<Produto>> PesquisaRangePrecoAsync(
             double? precoMin,
             double? precoMax);
    }
}