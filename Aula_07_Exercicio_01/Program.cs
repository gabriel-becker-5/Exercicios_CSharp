// crie um programa que peça ao usuário um numero de 1 a 3
// utilize switch para exibir:
// 1 - bom dia, 2 - boa tarde, 3 - boa noite, caso outro numero exiba 'opção inválida'

int numeroDoUsuario;

Console.Write("Digite um número de 1 a 3: ");
numeroDoUsuario = int.Parse(Console.ReadLine());

switch (numeroDoUsuario)
{
    case 1:
        Console.WriteLine("Bom dia!");
        break;
    case 2:
        Console.WriteLine("Boa tarde!");
        break;
    case 3:
        Console.WriteLine("Boa noite!");
        break;
    default:
        Console.WriteLine("Opção inválida!");
        break;
}