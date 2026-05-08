// peça 5 numeros ao usuário
// armazene em um array
// mostre apenas os numeros maiores que 10

int[] numeros = new int[5];

for (int i = 0; i < numeros.Length; i++)
{
    Console.Write("Digite o número " + (i + 1) + ": ");
    numeros[i] = int.Parse(Console.ReadLine());
}

for (int i = 0; i < numeros.Length; i++)
{
    if (numeros[i] > 10)
        Console.WriteLine("Número " + (i + 1) + " > 10: " + numeros[i]);
}