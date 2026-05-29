namespace Aula_15_Poo_Exercicio_1
{
    internal class Circulo : IFormaGeometrica
    {
        public double Raio { get; private set; }
        public double CalcularArea()
        {
            return Math.Pow(Raio, 2) * Math.PI;
        }

        public double CalcularPerimetro()
        {
            return 2 * Math.PI * Raio;
        }

        public void ApresentarDados()
        {
            Console.WriteLine("===== Círculo =====");
            Console.WriteLine($"Raio Fornecido: {Raio}");
            Console.WriteLine($"Área: {CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {CalcularPerimetro():F2}");
        }

        public Circulo(double raio)
        {
            Raio = raio;
        }
    }
}