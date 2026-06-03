namespace Aula_17_Poo_Desafio
{
    class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException(decimal saldo, decimal valorSolicitado)
    : base($"Saldo insuficiente! Saldo Atual: {saldo:C2} | Valor Solicitado: {valorSolicitado:C2}")
        {
        }
    }
}