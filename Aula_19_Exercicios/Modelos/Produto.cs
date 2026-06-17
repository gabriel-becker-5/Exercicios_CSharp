/* Exercício 1 - Estrutura o projeto e o modelo Produto
Crie um novo projeto console: CatalogoProdutos. 
Crie as pastas: Modelos, Interfaces, Repositorios, Excecoes e Servicos.
Em Modelos/Produto.cs crie a classe Produto com: int Id, string Nome, string Categoria, decimal Preco.
Em Program.cs crie 5 produtos de categorias diferentes e exiba-os com foreach. */

namespace Aula_19_Exercicios.Modelos
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome {  get; private set; }
        public string Categoria { get; private set; }
        public decimal Preco {  get; private set; }

        public Produto(int id, string nome, string categoria, decimal preco)
        {
            Id = id;
            Nome = nome;
            Categoria = categoria;
            Preco = preco;
        }

        public Produto(string nome, string categoria, decimal preco)
        {
            Nome = nome;
            Categoria = categoria;
            Preco = preco;
        }
    }
}