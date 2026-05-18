namespace Aula_13_Poo_Desafio
{
    public class Guerreiro : Personagem
    {

        public override string Atacar()
        {
            return $"Ataca com Espada, causando {Dano} dano.";
        }

        public Guerreiro(string nome) : base(nome, 100, 30)
        {
        }
    }
}