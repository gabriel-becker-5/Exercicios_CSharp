// Exercício 03 - Polimorfismo com classe abstrata
// Sistema de pagamentos
// Classe abstrata 'Pagamento' com Valor e método abstrato Processar()
// Classe 'CartaoCredito' exibe "Pagamento de R$ X no cartão de crédito"
// Classe 'Pix' exibe "Pagamento de R$ X via Pix"
// Classe 'Boleto': exibe "Boleto de R$ X gerado com vencimento em 3 dias"
// Crie uma lista com os três tipos e processe todos com um foreach

using Aula_14_Poo_Exercicio_3;

List<Pagamento> pagamentos =
[
    new Boleto(100.5m),
    new CartaoCredito(100.5m),
    new Pix(100.5m)
];

foreach (Pagamento pagamento in pagamentos)
{
    Console.WriteLine(pagamento.Processar());
};