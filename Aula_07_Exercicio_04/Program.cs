// receba 5 numeros e armazene em um array
// crie um novo array onde cada valor seja o dobro do original
// exiba os dois arrays

int qtdNumeros = 5;
int[] numerosInformados = new int[qtdNumeros];
int[] NumerosDobrados = new int[qtdNumeros];
int somaNumerosInformados = 0;
int somaNumerosDobrados = 0;

for (int i = 0; i < qtdNumeros; i++)
{
    Console.Write("Informe o " + (i + 1) + "º número: ");
    numerosInformados[i] = int.Parse(Console.ReadLine());
    somaNumerosInformados += numerosInformados[i];
}

for (int i = 0; i < numerosInformados.Length; i++)
{
    NumerosDobrados[i] = numerosInformados[i] * 2;
    somaNumerosDobrados += NumerosDobrados[i];
}

Console.WriteLine($"Soma dos Números Informados: {somaNumerosInformados}");
Console.WriteLine($"Soma dos Números Dobrados: {somaNumerosDobrados}");