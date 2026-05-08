// receba 10 numeros e armazene em um array
// exiba quantos são pares, impares, média dos números, o maior valor e o menor valor

int qtdNumeros = 10;
int[] numerosInformados = new int[qtdNumeros];
int contadorNumerosPares = 0;
int contadorNumerosImpares = 0;
decimal somaDosNumeros = 0;
int menorNumero = int.MaxValue;
int maiorNumero = int.MinValue;

for (int i = 0; i < qtdNumeros; i++)
{
    Console.Write("Informe o " + (i + 1) + "º número: ");
    numerosInformados[i] = int.Parse(Console.ReadLine());

    if (numerosInformados[i] % 2 == 0)
    {
        contadorNumerosPares++;
    }
    else
    {
        contadorNumerosImpares++;
    }

    somaDosNumeros += numerosInformados[i];

    if (numerosInformados[i] < menorNumero)
    {
        menorNumero = numerosInformados[i];
    }

    if (numerosInformados[i] > maiorNumero)
    {
        maiorNumero = numerosInformados[i];
    }
}

decimal mediaDosNumeros = somaDosNumeros / qtdNumeros;

Console.WriteLine($"Qtd. Pares: {contadorNumerosPares}");
Console.WriteLine($"Qtd. Impares: {contadorNumerosImpares}");
Console.WriteLine($"Média dos números: {mediaDosNumeros}");
Console.WriteLine($"Menor Número: {menorNumero}");
Console.WriteLine($"Maior Número: {maiorNumero}");