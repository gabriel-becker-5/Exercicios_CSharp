namespace Aula_13_Poo_Exercicio_5
{
    public class ContaCorrente : ContaBancaria
    {
        public const decimal taxaManutencao = 0.05m;

        public decimal DeduzirTaxa()
        {
            return Saldo -= Saldo * taxaManutencao;
        }

        public override void TipoDescricao()
        {
            Console.WriteLine($"Tipo da Conta: Corrente. Saldo: R$ {Saldo}");
        }

        public ContaCorrente(decimal saldo) : base(saldo)
        {
            Saldo = saldo;
        }
    }
}