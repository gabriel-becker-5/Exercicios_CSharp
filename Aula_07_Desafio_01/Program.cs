// Receba 10 numeros e armazene em um array principal
// Separe os números pares e ímpares em arrays distintos
// Exibir os resultados de cada array com FOR

int qtdNumeros = 10;
int[] numeros = new int[qtdNumeros];
int contadorNumerosImpares = 0;
int contadorNumerosPares = 0;
int[] numerosImpares = new int[qtdNumeros];
int[] numerosPares = new int[qtdNumeros];

for (int i = 0; i < numeros.Length; i++)
{

    Console.Write($"Digite o {(i + 1)}º número: ");
    numeros[i] = int.Parse(Console.ReadLine());

    if (numeros[i] % 2 == 0)
    {
        numerosPares[contadorNumerosPares] = numeros[i];
        contadorNumerosPares++;
    }
    else
    {
        numerosImpares[contadorNumerosImpares] = numeros[i];
        contadorNumerosImpares++;
    }
}

Console.WriteLine("Array Par: ");
for (int i = 0; i < contadorNumerosPares; i++)
{
    Console.Write($"{numerosPares[i]}, ");
}
Console.WriteLine("");

Console.WriteLine("Array Impar: ");
for (int i = 0; i < contadorNumerosImpares; i++)
{
    Console.Write($"{numerosImpares[i]}, ");
}