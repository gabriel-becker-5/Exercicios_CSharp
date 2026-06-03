namespace Aula_17_Poo_Desafio
{
    class ContaBancaria
    {
        public string Titular {  get; private set; }
        public decimal Saldo { get; private set; }

        public ContaBancaria(string titular, decimal saldo)
        {
            if (saldo < 0)
            {
                Saldo = 0;
            }
            else
            {
                Saldo = saldo;
            }
            Titular = titular;
        }

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
                throw new ValorInvalidoException();
            
            Saldo += valor;
        }

        public void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new ValorInvalidoException();

            if (valor > Saldo)
                throw new SaldoInsuficienteException(Saldo, valor);
            
            Saldo -= valor;
        }
    }
}