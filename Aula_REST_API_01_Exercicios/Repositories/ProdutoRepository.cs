using Aula_REST_API_01_Exercicios.Data;
using Aula_REST_API_01_Exercicios.Interfaces;
using Aula_REST_API_01_Exercicios.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula_REST_API_01_Exercicios.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<Produto>> GetTodosAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto?> GetPorIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<Produto> CriarAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task AtualizarAsync(Produto produto)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Produto>> PesquisaRangePrecoAsync(
             decimal? precoMin,
             decimal? precoMax)
        {
            var consulta = _context.Produtos.AsQueryable();

            if (precoMin.HasValue)
                consulta = consulta.Where(p => p.Preco >= precoMin.Value);

            if (precoMax.HasValue)
                consulta = consulta.Where(p => p.Preco <= precoMax.Value);

            return await consulta.ToListAsync();
        }
    }
}