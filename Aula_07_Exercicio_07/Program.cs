// receba 5 numeros e armazene em um array
// exiba os valores na ordem inversa

int qtdNumeros = 5;
int[] numerosInformados = new int[qtdNumeros];

for (int i = 0; i < qtdNumeros; i++)
{
    Console.Write("Informe o " + (i + 1) + "º número: ");
    numerosInformados[i] = int.Parse(Console.ReadLine());
}

for (int i = (qtdNumeros - 1); i > -1; i--)
{
    Console.WriteLine($"{i + 1}º número digitado: {numerosInformados[i]}");
}