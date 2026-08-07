using Aula_REST_API_01_Exercicios.Models;

namespace Aula_REST_API_01_Exercicios.Interfaces
{
    public interface IProdutoService
    {
        public Task<List<Produto>> GetTodosAsync();

        public Task<Produto?> GetPorIdAsync(int id);

        public Task<Produto> CriarAsync(ProdutoDto dto);

        public Task<bool> AtualizarAsync(int id, ProdutoDto dto);

        public Task<bool> DeletarAsync(int id);

        public Task<List<Produto>> PesquisaRangePrecoAsync(
            decimal? precoMin,
            decimal? precoMax);
    }
}