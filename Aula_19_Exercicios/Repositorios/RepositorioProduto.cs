/* Exercício 2 - Interface + Repositório com LINQ
Crie IRepositorioProduto com:
void Adicionar(Produto p), List<Produto> ListarTodos() e List<Produto> BuscarPorCategoria(string categoria)
Implemente RepositorioProduto usando List<Produto> internamente. Use LINQ (where) em BuscarPorCategoria. 
No Main, popule o repositório e teste a busca por categoria. */

/* Exercício 4 - Instalar e usar um pacote NuGet
Instale o pacote ConsoleTables: dotnet add package ConsoleTables.
Crie um método ExibirTabela(List<Produto> produtos) que:
- Cria uma ConsoleTable com colunas Id, Nome, Categoria, Preço.
- Adiciona uma linha (AddRow) para cada produto e Chama table.Write() para exibir no console.
Use LINQ para exibir a tabela ordenada por Preço (OrderBy). */

using Aula_19_Exercicios.Excecoes;
using Aula_19_Exercicios.Interfaces;
using Aula_19_Exercicios.Modelos;
using Aula_19_Exercicios.Servicos;
using ConsoleTables;

namespace Aula_19_Exercicios.Repositorios
{
    public class RepositorioProduto : IRepositorioProduto
    {
        private List<Produto> _produtos = new()
        {   
            new Produto(1, "Notebook Dell Inspiron 15", "Informática", 4299.90m),
            new Produto(2, "Tênis Adidas Ultraboost", "Esportes", 899.90m),
            new Produto(3, "Geladeira Brastemp Frost Free", "Eletrodomésticos", 3899.90m),
            new Produto(4, "Mesa de Escritório", "Móveis", 599.90m),
            new Produto(5, "Livro Clean Code", "Livros", 129.90m)
        };

        public Produto BuscarPorId(int id)
        {
            return _produtos.FirstOrDefault(p => p.Id == id) 
                ?? throw new ProdutoNaoEncontradoException(id);
        }

        public void Adicionar(Produto p)
        {
            _produtos.Add(new Produto(_produtos.Count + 1, p.Nome, p.Categoria, p.Preco));
        }

        public List<Produto> ListarTodos()
        {
            return _produtos;
        }

        public List<Produto> BuscarPorCategoria(string categoria)
        {
            var produtosFiltrados = _produtos.Where(p => p.Categoria.ToUpper() == categoria.ToUpper()).ToList();
            return produtosFiltrados;
        }

        public void ExibirTabela()
        {
            ConsoleTable tabelaConsole = new ConsoleTable("Id", "Nome", "Categoria", "Preço em R$");
            foreach (Produto produto in _produtos.OrderByDescending(p => p.Preco))
                tabelaConsole.AddRow(produto.Id, produto.Nome, produto.Categoria, produto.Preco);
            tabelaConsole.Write();
        }

        async public void ExibirTabelaEmDolar()
        {
            CotacaoService cotarDolar = new CotacaoService();
            decimal cotacaoDolarHoje = await cotarDolar.ObterCotacaoDolarAsync();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"===== Cotação do Dólar Hoje: {cotacaoDolarHoje:C4} =====");
            Console.WriteLine();
            ConsoleTable tabelaConsole = new ConsoleTable("Id", "Nome", "Categoria", "Preço em R$", "Preço em U$D");
            foreach (Produto produto in _produtos.OrderByDescending(p => p.Preco))
                tabelaConsole.AddRow(produto.Id, produto.Nome, produto.Categoria, produto.Preco, (produto.Preco / cotacaoDolarHoje).ToString("F2"));
            tabelaConsole.Write();
        }
    }
}