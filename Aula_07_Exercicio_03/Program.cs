// receba 5 numeros + armazene em um array
// calcule e exiba o produto de todos os números

int qtdNumeros = 5;
int[] numerosInformados = new int[qtdNumeros];
int produtoDosNumeros = 0;

for (int i = 0; i < qtdNumeros; i++)
{
    Console.Write("Informe o " + (i + 1) + "º número: ");
    numerosInformados[i] = int.Parse(Console.ReadLine());
}

for (int i = 0; i < qtdNumeros; i++)
{
    if (produtoDosNumeros == 0)
    { produtoDosNumeros = 1; }

    produtoDosNumeros = produtoDosNumeros * numerosInformados[i];
}

Console.WriteLine("Produto dos números informados: " + produtoDosNumeros);