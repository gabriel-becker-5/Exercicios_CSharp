namespace Aula_15_Poo_Desafio
{
    interface IPagamento
    {
        /// <summary>
        /// Processa um pagamento.
        /// </summary>
        /// <param name="valorPagamento">Valor da operação / pagamento a ser realizado.</param>
        /// <returns>Valor final da operação + Taxas ou Vencimento (se aplicável).</returns>
        decimal Pagar(decimal valorPagamento);
        
        /// <summary>
        /// Exibe o comprovante do pagamento realizado.
        /// </summary>
        void ExibirComprovante();
    }
}