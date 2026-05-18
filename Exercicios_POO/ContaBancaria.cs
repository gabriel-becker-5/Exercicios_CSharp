// Exercício 4 - ContaBancaria
// Crie classe 'ContaBancaria' com Titular e Saldo
// Crie um método que exibe o saldo

namespace Aula_10_Poo
{
    internal class ContaBancaria
    {
        public string Titular {  get; set; }
        public decimal Saldo { get; set; }

        public void ExibirSaldo()
        {
            Console.WriteLine($"Saldo em conta: R$ {Saldo}");
        }
    }
}