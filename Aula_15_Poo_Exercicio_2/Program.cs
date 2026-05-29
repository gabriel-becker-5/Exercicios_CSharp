// Múltiplas Interfaces
// Crie duas interfaces:
// IDescricao -> método string Descrever()
// ICalculavel -> método double Calcular()
// Crie a classe Produto que implemente as duas interfaces
// Exiba a descrição e resultado do cálculo

using Aula_15_Poo_Exercicio_2;

List<Produto> produtos =
[
    new Produto("Ventilador Super Forte 220V", 200),
    new Produto("SmarTV 4K Cores Vividas", 2500),
    new Produto("Caixa de som JBL Bluetooth", 599)
];

foreach (Produto produto in produtos)
{
    Console.WriteLine($"Descrição: {produto.Descrever()}");
    Console.WriteLine($"Preço Original: R$ {produto.Preco}");
    Console.WriteLine($"Preço à vista: R$ {produto.Calcular()}");
}