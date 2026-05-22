// Sistema de e-commerce com desconto polimórfico
// Construa um mini-sistema de carrinho de compras:
// Classe abstrata Produto com Nome, Preço e método CalcularDesconto()
// ProdutoFisico: 5% de desconto + R$ 15,00 de frete
// ProdutoDigital: 15% de desconto, sem frete
// ProdutoAssinatura: 25% de desconto + R$ 9,90/mês de mensalidade
// Crie um "carrinho" List<Produto> com pelo menos um de cada tipo
// Exiba nome, preço original, desconto aplicado e preço final de cada item
// Calcule e exiba o total do carrinho ao final

using Aula_14_Poo_Desafio;

List<Produto> produtos =
[
    new ProdutoAssinatura("HBO Max 30 dias", 59.90m),
    new ProdutoDigital("GTA V X Box Series S", 599.90m),
    new ProdutoFisico("Tábua de Carne 30x30cm", 49.90m)
];

decimal valorTotalCarrinho = 0;

foreach (Produto produto in produtos)
{
    valorTotalCarrinho = produto.PrecoFinalProduto();
    Console.WriteLine($"Produto: {produto.Nome} | Preço Original: R$ {produto.Preco} | Desconto: R$ {produto.CalcularDesconto()} | Preço Final: R$ {valorTotalCarrinho}");
}

Console.WriteLine($"Valor Total do Carrinho: R$ {valorTotalCarrinho}");