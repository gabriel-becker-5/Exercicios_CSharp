// Preencha um array com 5 numeros
// Não permita numeros negativos (while)
// Exiba todos os valores válidos ao final

int qtdNumeros = 5;
int[] numerosInformados = new int[qtdNumeros];

for (int i = 0; i < qtdNumeros; i++)
{
    Console.Write("Informe o " + (i + 1) + "º número (SOMENTE POSITIVOS): ");
    numerosInformados[i] = int.Parse(Console.ReadLine());

    while (numerosInformados[i] < 0)
    {
        Console.WriteLine("Número digitado inválido, digite um número positivo");
        Console.Write("Informe o " + (i + 1) + "º número (SOMENTE POSITIVOS): ");
        numerosInformados[i] = int.Parse(Console.ReadLine());
    }
}

for (int i = 0; i < qtdNumeros; i++)
{
    Console.WriteLine($"{(i + 1)}º número válido: {numerosInformados[i]}");
}