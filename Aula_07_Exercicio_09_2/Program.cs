// receba 5 numeros e armazene em um array
// ordene os valores em ordem crescente (sem metodos prontos)
// exiba o resultado

int qtdNumeros = 5;
int[] numerosInformados = new int[qtdNumeros];
int temporario;
bool houveTroca;
int contador;

for (int i = 0; i < qtdNumeros; i++)
{
    Console.Write("Informe o " + (i + 1) + "º número: ");
    numerosInformados[i] = int.Parse(Console.ReadLine());
}

for (int x = 0; x < (qtdNumeros - 1); x++)
{
    houveTroca = false;

    for (int i = 1; i < (qtdNumeros - x); i++)
    {
        if (numerosInformados[i] < numerosInformados[i - 1])
        {
            temporario = numerosInformados[i];
            numerosInformados[i] = numerosInformados[i - 1];
            numerosInformados[i - 1] = temporario;
            houveTroca = true;
        }
    }

    if (houveTroca == false)
    {
        break;
    }
}

for (int i = 0; i < qtdNumeros; i++)
    Console.WriteLine($"Resultado: {numerosInformados[i]}");