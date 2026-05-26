// Criar e implementar uma interface
// Crie a interface IFormaGeometrica com:
// double CalcularArea()
// double CalcularPerimetro()
// Implemente nas classes retangulo e circulo
// Exiba área e perímetro de cada forma

namespace Aula_15_Poo_Exercicio_1
{
    internal class Retangulo : IFormaGeometrica
    {
        double Comprimento { get; set; }
        double Largura { get; set; }

        public double CalcularArea()
        {
            return Comprimento * Largura;
        }

        public double CalcularPerimetro()
        {
            throw new NotImplementedException();
        }
    }
}