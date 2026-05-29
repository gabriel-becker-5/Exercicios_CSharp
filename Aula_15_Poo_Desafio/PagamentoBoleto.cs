namespace Aula_15_Poo_Desafio
{
    public class PagamentoBoleto : IPagamento
    {
        public DateTime DataVencimento { get; private set; }
        public decimal ValorPagamento { get; private set; }

        public decimal Pagar(decimal valorPagamento)
        {
            ValorPagamento = valorPagamento;
            DataVencimento = DateTime.Today.AddDays(3);
            return ValorPagamento;
        }

        public void ExibirComprovante()
        {
            Console.WriteLine();
            Console.WriteLine("=== Pagamento em Boleto ===");
            Console.WriteLine($"Valor do Pagamento: R$ {ValorPagamento}");
            Console.WriteLine($"Data de Vencimento: {DataVencimento:dd/MM/yyyy}");
        }
    }
}