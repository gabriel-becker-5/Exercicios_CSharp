namespace Aula_11_Poo
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