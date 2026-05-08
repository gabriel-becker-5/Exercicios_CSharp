// Crie um programa que: pergunte o nome do usuário, sua idade (converta para tipo byte)
// Exiba no console o nome e a idade informadas

Console.Write("Informe seu nome: ");
string nome = Console.ReadLine();
Console.WriteLine();

Console.Write("Informe sua idade: ");
byte idade = byte.Parse(Console.ReadLine());
Console.WriteLine();

Console.WriteLine($"Nome: {nome} Idade: {idade}");