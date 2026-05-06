namespace Aula_11_Poo
{
    internal class ContaBancaria
    {
        public string Titular { get; set; }
        public decimal Saldo { get; set; }
        public int NumeroConta { get; set; }

        public void ExibirSaldo(int NumeroConta)
        {
            Console.WriteLine($"Saldo em conta: R$ {Saldo}");
        }

        public void Depositar(decimal valor, int NumeroConta)
        {
            if (valor > 0)
            {
                Saldo += valor;
                ExibirSaldo(NumeroConta);
            }
            else
            {
                Console.WriteLine("Digite um número positivo para depositar.");
            }
        }

        public void Sacar(decimal valor, int NumeroConta)
        {
            if (Saldo < valor)
                Console.WriteLine("Saldo insuficiente!");
            else if (valor > 0)
            {
                Saldo -= valor;
                ExibirSaldo(NumeroConta);
            }
            else
            {
                Console.WriteLine("Digite um número positivo para sacar.");
            }
        }
    }
}