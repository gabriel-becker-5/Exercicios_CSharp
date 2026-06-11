namespace Aula_16_Poo_Desafio
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Categoria { get; private set; }
        public decimal Preco {  get; private set; }
        public int Estoque { get; private set; }

        public Produto(int id, string nome, string categoria, decimal preco, int estoque)
        {
            Id = id;
            Nome = nome;
            Categoria = categoria;
            Preco = preco;
            Estoque = estoque;
        }
    }
}