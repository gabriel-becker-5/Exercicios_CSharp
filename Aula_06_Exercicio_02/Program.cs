// peça 5 nomes ao usuário
// armazene em um array
// exiba todos ao final

string[] nomes = new string[5];

for (int i = 0; i < nomes.Length; i++)
{
    Console.Write("Digite o nome " + (i + 1) + ": ");
    nomes[i] = Console.ReadLine();
}

for (int i = 0; i < nomes.Length; i++)
{
    Console.WriteLine("Nome " + (i + 1) + ": " + nomes[i]);
}