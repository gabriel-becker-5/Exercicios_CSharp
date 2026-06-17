/* Exercício 2 - Interface + Repositório com LINQ
Crie IRepositorioProduto com:
void Adicionar(Produto p), List<Produto> ListarTodos() e List<Produto> BuscarPorCategoria(string categoria)
Implemente RepositorioProduto usando List<Produto> internamente. Use LINQ (where) em BuscarPorCategoria. 
No Main, popule o repositório e teste a busca por categoria. */

using Aula_19_Exercicios.Modelos;

namespace Aula_19_Exercicios.Interfaces
{
    interface IRepositorioProduto
    {
        void Adicionar(Produto p);
        List<Produto> ListarTodos();
        List<Produto> BuscarPorCategoria(string categoria);
        Produto BuscarPorId(int id);
    }
}