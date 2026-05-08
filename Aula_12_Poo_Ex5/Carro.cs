// Crie classe carro com: marca, modelo, velocidade atual
// Regras:
// velocidade não pode ser negativa
// criar método para acelerar
// criar método para frear
// exibir velocidade atual

namespace Aula_12_Poo_Ex5
{
    internal class Carro
    {
        private string marca;
        private string modelo;
        private int velocidade;

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        public int Velocidade
        {
            get { return velocidade; }
            private set
            {
                if (value >= 0)
                {
                    velocidade = value;
                }
            }

        }

        public void Acelerar(int velocidade)
        {
            if (velocidade > 0)
            {
                Velocidade += velocidade;
            }
        }

        public void Frear(int reducao)
        {
            if (reducao <= Velocidade)
            {
                Velocidade -= reducao;
            }
        }

        public void ApresentarDados()
        {
            Console.WriteLine($"Marca: {Marca}. Modelo: {Modelo}. Velocidade Atual: {Velocidade} km/h.");
        }
    }
}