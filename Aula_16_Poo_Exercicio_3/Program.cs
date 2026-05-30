// Filtrar com LINQ Where
// Crie uma List<int> com os números: {4, 17, 3, 22, 9, 31, 6, 14, 28}
// Use LINQ para:
// Filtrar apenas os números maiores que 10
// Filtrar apenas os números pares
// Contar quantos são maiores que 15
// Exiba os resultados de cada operação

List<int> numeros = new List<int> { 4, 17, 3, 22, 9, 31, 6, 14, 28 };

var numerosMaioresQue10 = numeros.Where(x => x > 10).ToList();

Console.WriteLine("===== Números maiores que 10 =====");
foreach (var numero in numerosMaioresQue10)
{
    Console.WriteLine($"{numero}");
}

Console.WriteLine("");
Console.WriteLine("===== Números Pares =====");
var numerosPares = numeros.Where(x => x % 2 == 0).ToList();
foreach (var numero in numerosPares)
{
    Console.WriteLine($"{numero}");
}

Console.WriteLine("");
Console.WriteLine("===== Qtd. Números Maiores Que 15 =====");
int qtdMaioresQue15 = numeros.Count(x => x > 15);
Console.WriteLine(qtdMaioresQue15);