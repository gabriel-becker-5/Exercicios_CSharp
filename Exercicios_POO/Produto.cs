// Exercício 3 - Produto
// Crie uma classe 'Produto' com: Nome e Preço
// Crie 2 objetos diferentes e exiba suas informações

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