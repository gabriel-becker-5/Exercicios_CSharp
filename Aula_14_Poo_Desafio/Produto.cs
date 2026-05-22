namespace Aula_14_Poo_Desafio
{
    public abstract class Produto
    {
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public abstract decimal CalcularDesconto();
        public abstract decimal PrecoFinalProduto();

        public Produto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }
    }
}