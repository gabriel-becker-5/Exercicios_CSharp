// Criar classe Conta
// Deve possuir saldo privado - ok
// Permita depositar valores positivos - ok
// Permita sacar apenas se houver saldo - ok
// Exibir saldo atual - ok

namespace Aula_12_Poo_Ex3
{
    internal class Conta
    {

        private decimal saldo;

        public decimal Saldo
        {
            get { return saldo; }
            private set { saldo = value; }
        }

        public void Depositar(decimal valorDeposito)
        {
            if (valorDeposito > 0)
            {
                Saldo += valorDeposito;
            }
        }

        public void Sacar(decimal valorSaque)
        {
            if (valorSaque > 0 && valorSaque <= Saldo)
            {
                Saldo -= valorSaque;
            }
        }
    }
}