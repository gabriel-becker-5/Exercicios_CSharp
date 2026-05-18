namespace Aula_13_Poo_Exercicio_5
{
    internal class ContaPoupanca : ContaBancaria
    {
        public const decimal taxaRendimento = 0.05m;

        public decimal AplicarJuros()
        {
            return Saldo += Saldo * taxaRendimento;
        }

        public override void TipoDescricao()
        {
            Console.WriteLine($"Tipo da Conta: Poupança. Saldo: R$ {Saldo}");
        }

        public ContaPoupanca(decimal saldo) : base(saldo)
        {
            Saldo = saldo;
        }
    }
}