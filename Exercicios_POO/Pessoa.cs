// Exercício 2 - Pessoa
// Crie uma classe Pessoa com: Nome e Idade
// Crie um método que exiba: "Olá, meu nome é X e tenho Y anos".

namespace Aula_10_Poo
{
    internal class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        public void ExibirDadosPessoa()
        {
            Console.WriteLine($"Olá, meu nome é {Nome} e tenho {Idade} anos.");
        }
    }
}