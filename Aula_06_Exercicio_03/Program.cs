// armazene 5 numeros
// calcule a soma total
// exiba o resultado

int[] numeros = new int[5];

for (int i = 0; i < numeros.Length; i++)
{
    Console.Write("Digite o número " + (i + 1) + ": ");
    numeros[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("Soma dos números informados: " + numeros.Sum());