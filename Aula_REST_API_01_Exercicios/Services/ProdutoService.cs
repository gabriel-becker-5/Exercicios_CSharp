using Aula_REST_API_01_Exercicios.Interfaces;
using Aula_REST_API_01_Exercicios.Models;

namespace Aula_REST_API_01_Exercicios.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<List<Produto>> GetTodosAsync()
        {
            return await _produtoRepository.GetTodosAsync();
        }

        public async Task<Produto?> GetPorIdAsync(int id)
        {
            return await _produtoRepository.GetPorIdAsync(id);
        }

        public async Task<Produto> CriarAsync(ProdutoDto dto)
        {
            Produto novoProduto = new Produto
            {
                Nome = dto.Nome,
                Preco = dto.Preco,
                EmailFornecedor = dto.EmailFornecedor
            };

            await _produtoRepository.CriarAsync(novoProduto);

            return novoProduto;
        }

        public async Task<bool> AtualizarAsync(int id, ProdutoDto dto)
        {
            Produto produto = await _produtoRepository.GetPorIdAsync(id);

            if (produto == null)
            {
                return false;
            }

            produto.Nome = dto.Nome;
            produto.Preco = dto.Preco;
            produto.EmailFornecedor = dto.EmailFornecedor;

            await _produtoRepository.AtualizarAsync(produto);
            return true;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            Produto produto = await _produtoRepository.GetPorIdAsync(id);

            if (produto == null)
            {
                return false;
            }

            await _produtoRepository.DeletarAsync(produto);
            return true;
        }

        public async Task<List<Produto>> PesquisaRangePrecoAsync(
            decimal? precoMin,
            decimal? precoMax)
        {
            if (precoMax < precoMin)
            {
                return null;
            }

            return await _produtoRepository.PesquisaRangePrecoAsync(precoMin, precoMax);
        }
    }
}