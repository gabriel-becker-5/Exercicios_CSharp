namespace Aula_13_Poo_Exercicio_3
{
    public class Circulo : Forma
    {
        public double Raio { get; private set; }
        
        public override double CalcularArea()
        {
            return Math.Pow(Raio, 2) * Math.PI;
        }

        public Circulo(double raio)
        {
            Raio = raio;
        }
    }
}