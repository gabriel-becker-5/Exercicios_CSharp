namespace Aula_13_Poo_Exercicio_3
{
    public class Retangulo : Forma
    {
        public double Largura;
        public double Altura;
        public double Area;

        public override void CalcularArea()
        {
            Console.WriteLine("Área do Retangulo: " + Largura * Altura);
        }

        public Retangulo(double largura, double altura)
        {
            Largura = largura;
            Altura = altura;
        }

    }
}
