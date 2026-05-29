namespace Aula_15_Poo_Exercicio_1
{
    internal class Retangulo : IFormaGeometrica
    {
        public double Comprimento { get; private set; }
        public double Largura { get; private set; }

        public double CalcularArea()
        {
            return Comprimento * Largura;
        }

        public double CalcularPerimetro()
        {
            return 2 * (Comprimento + Largura);
        }

        public void ApresentarDados()
        {
            Console.WriteLine("===== Retangulo =====");
            Console.WriteLine($"Comprimento e Largura Fornecidos: {Comprimento} x {Largura}");
            Console.WriteLine($"Área: {CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {CalcularPerimetro():F2}");
        }

        public Retangulo(double comprimento, double largura)
        {
            Comprimento = comprimento;
            Largura = largura;
        }
    }
}