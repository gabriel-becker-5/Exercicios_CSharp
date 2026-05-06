namespace Aula_10_Poo
{
    internal class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public void ExibirDadosProduto()
        {
            Console.WriteLine($"Produto: {Nome}  |  Preço: R$ {Preco}");
        }
    }
}