namespace Aula_13_Poo_Exercicio_3
{
    public class Retangulo : Forma
    {
        public double Largura { get; private set; }
        public double Altura { get; private set; }

        public override double CalcularArea()
        {
            return Largura * Altura;
        }

        public Retangulo(double largura, double altura)
        {
            Largura = largura;
            Altura = altura;
        }

    }
}