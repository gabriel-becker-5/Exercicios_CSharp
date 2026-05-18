namespace Aula_13_Poo_Desafio
{
    public class Arqueiro : Personagem
    {
        public int Flecha { get; private set; }

        public override string Atacar()
        {
            if (Flecha >= 1)
            {
                Flecha -= 1;
                return $"Ataca com Arco & Flecha, causando {Dano} dano.";
            }
            else
            {
                return $"Não há flechas suficientes.";
            }
        }

        public override void ExibirInfosPersonagem()
        {
            base.ExibirInfosPersonagem();
            Console.WriteLine($"Flecha: {Flecha}");
        }

        public Arqueiro(string nome) : base(nome, 100, 20)
        {
            Flecha = 10;
        }
    }
}