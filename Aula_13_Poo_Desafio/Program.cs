// Simular Sistema de RPG
// Criar sistema de personagens para um jogo
// Classe abstrata com Nome, Vida e método abstrato Atacar()
// Classe Guerreiro: ataca com espada (dano fixo de 30)
// Classe Mago: ataca com magia (dano 50, consome 10 de mana por ataque)
// Classe Arqueiro: ataca com flecha (dano 20, verifica se tem flechas)
// Crie um objeto de cada tipo e simule um turno de combate
// Exiba nome, vida atual e resultado do ataque de cada personagem

using Aula_13_Poo_Desafio;

//int turnos = 15;
//Guerreiro guerreiro1 = new Guerreiro("Ragnar");
//Mago mago1 = new Mago("Gandalf");
//Arqueiro arqueiro1 = new Arqueiro("Robin");

//for (int i = 0; i < turnos; i++)
//{
//    Console.WriteLine("======================================");
//    Console.WriteLine($"Turno: {i + 1}");
//    Console.WriteLine("======================================");
//    guerreiro1.ExibirInfosPersonagem();
//    Console.WriteLine(guerreiro1.Atacar());
//    Console.WriteLine("");
//    mago1.ExibirInfosPersonagem();
//    Console.WriteLine(mago1.Atacar());
//    Console.WriteLine("");
//    arqueiro1.ExibirInfosPersonagem();
//    Console.WriteLine(arqueiro1.Atacar());
//}

List<Personagem> personagens = new()
{
    new Guerreiro("Ragnar"),
    new Mago("Gandalf"),
    new Arqueiro("Robin")
};

foreach (Personagem personagem in personagens)
{
    personagem.ExibirInfosPersonagem();
    personagem.Atacar();
};