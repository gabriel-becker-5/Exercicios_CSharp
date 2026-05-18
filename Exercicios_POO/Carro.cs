// Exercício 1 - Classe simples
// Crie classe chamada Carro com: marca e modelo
// Crie um objeto e exiba os valores no console

namespace Aula_10_Poo
{
    internal class Carro
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public void ExibirDadosCarro()
        {
            Console.WriteLine($"Marca: {Marca}. Modelo: {Modelo}.");
        }
    }
}