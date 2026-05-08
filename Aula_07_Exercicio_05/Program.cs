// receba 6 numeros e armazene em um array
// conte quantos são pares
// exiba o total

int qtdNumeros = 6;
int[] numerosInformados = new int[qtdNumeros];
int contadorNumerosPares = 0;

for (int i = 0; i < qtdNumeros; i++)
{
    Console.Write("Informe o " + (i + 1) + "º número: ");
    numerosInformados[i] = int.Parse(Console.ReadLine());

    if (numerosInformados[i] % 2 == 0)
    {
        Console.WriteLine("Numero par");
        contadorNumerosPares++;
    }
    else
    {
        Console.WriteLine("Numero impar");
    }
}

Console.WriteLine($"Quantidade de números pares digitados: {contadorNumerosPares}");