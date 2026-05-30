// Trabalhar com Dictionary<K,V>
// Crie um Dictionary<string, int> com os pares:
// "Maçã" -> 3, "Banana" -> 7, "Laranja" -> 5
// Adicione "Uva" -> 10
// Exiba o valor de "Banana"
// Verifique se "Manga" existe com ContainsKey()
// Percorra o dicionário exibindo chave e valor

Dictionary<string, decimal> frutas = new Dictionary<string, decimal>
{
    { 
        "Maçã", 3.15m 
    },
    { 
        "Banana", 7.19m 
    },
    { 
        "Laranja", 5.99m 
    }
};

frutas.Add("Uva", 7.99m);

Console.WriteLine($"Fruta: Banana | Valor {frutas["Banana"]:c2}");

if (frutas.ContainsKey("Manga"))
{
    Console.WriteLine("Manga existe no dicionário.");
}
else
{
    Console.WriteLine("Manga não existe no dicionário.");
}

Console.WriteLine();
Console.WriteLine("===== Frutas cadastradas =====");
foreach (var fruta in frutas)
{
    Console.WriteLine($"Fruta: {fruta.Key} | Valor {fruta.Value:c2}");
}