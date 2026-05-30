// Trabalhar com List<T>
// Crie uma List<string> com 5 nomes de sua escolha
// Adicione mais 2 nomes com Add()
// Remova 1 nome com Remove()
// Exiba a quantidade total com Count
// Percorra a lista com foreach e exiba cada nome

List<string> nomes = new List<string>
{
    "Alice",
    "Bob",
    "Charlie",
    "Diana",
    "Edward"
};

nomes.Add("Fiona");
nomes.Add("George");
nomes.Remove("Charlie");

Console.WriteLine($"Quantidade de Nomes cadastrados: {nomes.Count()}");

foreach (var nome in nomes)
{
    Console.WriteLine($"Nome: {nome}");
}