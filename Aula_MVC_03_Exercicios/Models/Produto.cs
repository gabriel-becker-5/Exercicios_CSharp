namespace Aula_MVC_03_Exercicios.Models
{
    public class Produto
    {
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public string Categoria { get; private set; }

        public Produto(string nome, decimal preco, string categoria)
        {
            Nome = nome;
            Preco = preco;
            Categoria = categoria;
        }
    }
}