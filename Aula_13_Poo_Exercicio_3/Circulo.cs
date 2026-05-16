// Criar classe Abstrata chamada 'Forma'
// Metodo abstrato CalcularArea() que retorna double
// Criar classe retangulo com largura e altura
// Crie classe circulo com raio
// Implemente CalcularArea() em cada uma e exiba os resultados

namespace Aula_13_Poo_Exercicio_3
{
    public class Circulo : Forma
    {
        public double Raio;
        public double pi = 3.14159d;
        
        public override void CalcularArea()
        {
            Console.WriteLine("Área do Círculo: " + Math.Pow(Raio, 2) * 3.14159d);
        }

        public Circulo(double raio)
        {
            Raio = raio;
        }


    }
}
