// Sistema de pagamentos com interfaces e convenções
// Crie a interface IPagamento com Pagar(decimal valor) e ExibirComprovante()
// Implemente: PagamentoCartao (taxa 2%), PagamentoPix (sem taxa), PagamentoBoleto (vence em 3 dias)
// Requisitos obrigatórios: 
// Seguir todas as convenções de nomenclatura C#
// Documentação XML em todos os métodos da interface
// Usar List<IPagamento> para processar vários pagamentos
// Sem code smells (nomes claros, sem duplicação, métodos pequenos)

using Aula_15_Poo_Desafio;

List<IPagamento> pagamentos =
[
    new PagamentoBoleto(),
    new PagamentoCartao(),
    new PagamentoPix()
];

foreach (IPagamento pagamento in pagamentos)
{
    pagamento.Pagar(100);
    pagamento.ExibirComprovante();
}