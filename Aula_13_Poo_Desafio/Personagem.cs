namespace Aula_13_Poo_Desafio
{
    public abstract class Personagem
    {
        public string Nome {  get; protected set; }
        public int Vida { get; protected set; }
        public int Dano { get; protected set; }

        public abstract string Atacar();
        public virtual void ExibirInfosPersonagem()
        {
            Console.WriteLine($"Nome do Personagem: {Nome}.   Vida: {Vida}.");
        }

        public Personagem(string nome, int vida, int dano)
        {
            Nome = nome;
            Vida = vida;
            Dano = dano;
        }
    }
}