namespace Aula_15_Poo_Desafio
{
    public class PagamentoCartao : IPagamento
    {
        private const decimal TaxaCartao = 0.02m;
        public decimal ValorOriginal { get; private set; }
        public decimal ValorPagamento { get; private set; }
        public decimal Taxa { get; private set; }

        public decimal Pagar(decimal valorPagamento)
        {
            ValorOriginal = valorPagamento;
            Taxa = valorPagamento * TaxaCartao;
            ValorPagamento = valorPagamento + Taxa;
            return ValorPagamento;
        }

        public void ExibirComprovante()
        {
            Console.WriteLine();
            Console.WriteLine("=== Pagamento no Cartão de Crédito ===");
            Console.WriteLine($"Valor do Pagamento: R$ {ValorOriginal}");
            Console.WriteLine($"Taxa: R$ {Taxa}");
            Console.WriteLine($"Valor Total da Operação: R$ {ValorPagamento}");
        }
    }
}