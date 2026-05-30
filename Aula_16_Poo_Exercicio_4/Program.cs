// Transformar e ordenar com Select e OrderBy
// Crie uma List<string> com os nomes em minúsculo:
// { "ana", "carlos", "beatriz", "diego", "eva" }
// Use LINQ para:
// Transformar todos para MAIÚSCULO com Select
// Ordenar em ordem alfabética com OrderBy
// Ordenar do maior para o menor com OrderByDescending
// Exiba cada resultado

List<string> nomes = new List<string>
{
    "ana",
    "carlos",
    "beatriz",
    "diego",
    "eva"
};

var nomesMaiusculo = nomes.Select(x => x.ToUpper()).ToList();
Console.WriteLine("===== Nomes em Maiúsculo =====");
foreach (var nome in nomesMaiusculo)
{
    Console.WriteLine(nome);
}

var nomesOrdenados = nomes.OrderBy(x => x).ToList();
Console.WriteLine("===== Nomes em Ordem Alfabética =====");
foreach (var nome in nomesOrdenados)
{
    Console.WriteLine(nome);
}

var nomesOrdenadosDesc = nomes.OrderByDescending(x => x).ToList();
Console.WriteLine("===== Nomes em Ordem Decrescente =====");
foreach (var nome in nomesOrdenadosDesc)
{
    Console.WriteLine(nome);
}