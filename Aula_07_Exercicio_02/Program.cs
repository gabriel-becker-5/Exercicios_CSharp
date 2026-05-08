// receba 5 numeros
// armazene em um array
// conte quantos numeros são maiores do que a média
// exiba o resultado

int qtdNumeros = 5;
int[] numerosInformados = new int[qtdNumeros];
int contadorNumerosAcimaDaMedia = 0;
decimal mediaCalculada = 0m;

for (int i = 0; i < qtdNumeros; i++)
{
    Console.Write("Informe o " + (i + 1) + "º número: ");
    numerosInformados[i] = int.Parse(Console.ReadLine());
}

for (int i = 0; i < qtdNumeros; i++)
{
    mediaCalculada += numerosInformados[i];
}

mediaCalculada = mediaCalculada / qtdNumeros;

for (int i = 0; i < qtdNumeros; i++)
{
    if (numerosInformados[i] > mediaCalculada)
    {
        contadorNumerosAcimaDaMedia++;
    }

}

Console.WriteLine("Média dos números informados: " + mediaCalculada);
Console.WriteLine("Quantidade de números acima da média: " + contadorNumerosAcimaDaMedia);