// Sistema de Estoque com coleções e LINQ
// Crie uma classe Produto (Id, Nome, Categoria, Preco, Estoque)
// Popule uma List<Produto> com pelo menos 8 produtos de 3 categorias
// Use LINQ para gerar um relatório que exiba:
// Produtos com estoque < 5 (alerta de reposição)
// Produto mais caro e mais barato de cada categoria
// Valor total do estoque (Preço x Estoque) por categoria
// Top 3 produtos mais caros em ordem decrescente

using Aula_16_Poo_Desafio;

List<Produto> Produtos =
    [
        new Produto(1, "Ventilador", "Eletrodoméstico", 199.90m, 10),
        new Produto(2, "Aquecedor", "Eletrodoméstico", 99.90m, 50),
        new Produto(3, "Torradeira", "Eletrodoméstico", 299.90m, 20),
        new Produto(4, "Airfryer", "Eletrodoméstico", 299.90m, 2),
        new Produto(5, "Liquidificador", "Eletrodoméstico", 149.90m, 10),
        new Produto(6, "Cadeira de Praia", "Praia", 109.90m, 50),
        new Produto(7, "Caixa Térmica", "Praia", 139.90m, 40),
        new Produto(8, "Cama", "Móveis", 599.90m, 5),
        new Produto(9, "Armário", "Móveis", 1099.90m, 1),
        new Produto(10, "Sofá", "Móveis", 799.90m, 10)
    ];

// Relatório 1 | Produtos com estoque < 5 (alerta de reposição)
Console.WriteLine("=== Relatório: Produtos com Estoque Baixo ===");
List<Produto> produtosEstoqueBaixo = Produtos.Where(p => p.Estoque <= 5).ToList();
foreach (Produto produto in produtosEstoqueBaixo)
{
    Console.WriteLine($"Produto: {produto.Nome}  |  Categoria: {produto.Categoria}  |  Preço: {produto.Preco:C2}  |  Estoque: {produto.Estoque}");
}
Console.WriteLine();

// Relatório 2 | Produto mais caro e mais barato de cada categoria
Console.WriteLine("=== Relatório: Produto mais barato por categoria ===");
var produtoMaisBaratoPorCategoria = Produtos.GroupBy(p => p.Categoria).Select(grupo => grupo.MinBy(p => p.Preco));
foreach (var produto in produtoMaisBaratoPorCategoria)
{
    Console.WriteLine($"{produto.Nome} | {produto.Categoria} | {produto.Preco:C2}");
}
Console.WriteLine();

Console.WriteLine("=== Relatório: Produto mais caro por categoria ===");
var produtoMaisCaroPorCategoria = Produtos
    .GroupBy(p => p.Categoria)
    .Select(grupo => grupo
    .MaxBy(p => p.Preco));
foreach (var produto in produtoMaisCaroPorCategoria)
{
    Console.WriteLine($"{produto.Nome} | {produto.Categoria} | {produto.Preco:C2}");
}
Console.WriteLine();

// Relatório 3 | Valor total do estoque (Preço x Estoque) por categoria
Console.WriteLine("=== Relatório: Valor total do estoque por categoria ===");
var valorTotalEstoquePorCategoria = Produtos
    .GroupBy(p => p.Categoria)
    .Select(grupo => new
    {
        Categoria = grupo.Key,
        ValorTotalEstoque = grupo.Sum(p => p.Preco * p.Estoque)
    }).OrderByDescending(p => p.ValorTotalEstoque);

foreach (var produto in valorTotalEstoquePorCategoria)
{
    Console.WriteLine($"{produto.Categoria} | {produto.ValorTotalEstoque:C0}");
}
Console.WriteLine();

// Relatório 4 | Top 3 produtos mais caros em ordem decrescente
Console.WriteLine("=== Relatório: Top 3 produtos mais caros em ordem decrescente ===");
int topProdutos = 3;
var topNProdutosMaisCaros = Produtos.OrderByDescending(p => p.Preco).Take(topProdutos);
foreach (var produto in topNProdutosMaisCaros)
{
    Console.WriteLine($"{produto.Nome} | {produto.Preco:C2}");
}