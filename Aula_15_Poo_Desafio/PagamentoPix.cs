namespace Aula_15_Poo_Desafio
{
    public class PagamentoPix : IPagamento
    {
        public decimal ValorPagamento { get; private set; }

        public decimal Pagar(decimal valorPagamento)
        {
            ValorPagamento = valorPagamento;
            return ValorPagamento;
        }

        public void ExibirComprovante()
        {
            Console.WriteLine();
            Console.WriteLine("=== Pagamento no PIX ===");
            Console.WriteLine($"Valor do Pagamento: R$ {ValorPagamento}");
        }
    }
}