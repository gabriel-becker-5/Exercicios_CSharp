// receba 5 numeros e armazene em um array
// ordene os valores em ordem crescente (sem metodos prontos)
// exiba o resultado

int qtdNumeros = 5;
int[] numerosInformados = new int[qtdNumeros];
int menorNumero = int.MaxValue;
int segundoMenor = int.MaxValue;
int terceiroMenor = int.MaxValue;
int quartoMenor = int.MaxValue;
int maiorNumero = int.MaxValue;

for (int i = 0; i < qtdNumeros; i++)
{
    Console.Write("Informe o " + (i + 1) + "º número: ");
    numerosInformados[i] = int.Parse(Console.ReadLine());
    if (numerosInformados[i] < menorNumero)
    {
        menorNumero = numerosInformados[i];
    }
}

for (int i = 0; i < qtdNumeros; i++)
{
    if (numerosInformados[i] < segundoMenor && numerosInformados[i] > menorNumero)
    {
        segundoMenor = numerosInformados[i];
    }
}

for (int i = 0; i < qtdNumeros; i++)
{
    if (numerosInformados[i] < terceiroMenor && numerosInformados[i] > segundoMenor)
    {
        terceiroMenor = numerosInformados[i];
    }
}

for (int i = 0; i < qtdNumeros; i++)
{
    if (numerosInformados[i] < quartoMenor && numerosInformados[i] > terceiroMenor)
    {
        quartoMenor = numerosInformados[i];
    }
}

for (int i = 0; i < qtdNumeros; i++)
{
    if (numerosInformados[i] < maiorNumero && numerosInformados[i] > quartoMenor)
    {
        maiorNumero = numerosInformados[i];
    }
}

Console.WriteLine($"Números organizados em ordem crescente: {menorNumero}, {segundoMenor}, {terceiroMenor}, {quartoMenor} e {maiorNumero}");