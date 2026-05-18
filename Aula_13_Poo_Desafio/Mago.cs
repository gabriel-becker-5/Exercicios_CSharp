namespace Aula_13_Poo_Desafio
{
    public class Mago : Personagem
    {
        public int Mana { get; private set; }

        public override string Atacar()
        {
            if (Mana >= 10)
            {
                Mana -= 10;
                return $"Ataca com Magia, causando {Dano} dano.";
            }
            else
            {
                return $"Não há mana suficiente.";
            }
        }
        public override void ExibirInfosPersonagem()
        {
            base.ExibirInfosPersonagem();
            Console.WriteLine($"Mana: {Mana}");
        }

        public Mago(string nome) : base(nome, 100, 50)
        {
            Mana = 30;
        }
    }
}