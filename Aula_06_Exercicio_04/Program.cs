// receba 5 numeros
// mostre o maior deles

int[] numeros = new int[5];

for (int i = 0; i < numeros.Length; i++)
{
    Console.Write("Digite o número " + (i + 1) + ": ");
    numeros[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("O maior número informado é: " + numeros.Max());