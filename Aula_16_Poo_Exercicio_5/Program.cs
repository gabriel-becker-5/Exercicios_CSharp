/* Encadear operações LINQ
Crie uma classe Produto com Nome (string) e Preco (double)
Crie uma List<Produto> com pelo menos 6 produtos variados
Use LINQ encadeado para:
- Pegar apenas produtos com Preço > 20
- Ordenar por Nome
- Selecionar só o Nome
- Exibir o resultado + Soma e Média dos preços de TODOS */

using Aula_16_Poo_Exercicio_5;

List<Produto> produtos = new List<Produto>
{
    new Produto("Camiseta", 25.99),
    new Produto("Calça", 49.99),
    new Produto("Tênis", 89.99),
    new Produto("Boné", 15.50),
    new Produto("Jaqueta", 120.00),
    new Produto("Meias", 9.99)
};

var produtosFiltrados = produtos
    .Where(p => p.Preco > 20)
    .OrderBy(p => p.Nome)
    .Select(p => p.Nome);

Console.WriteLine("Produtos com preço > 20, ordenados por nome:");
foreach (var nome in produtosFiltrados)
{
    Console.WriteLine(nome);
}

double somaPrecos = produtos.Sum(p => p.Preco);
double mediaPrecos = produtos.Average(p => p.Preco);
Console.WriteLine($"Soma dos preços: {somaPrecos:C2}");
Console.WriteLine($"Média dos preços: {mediaPrecos:C2}");