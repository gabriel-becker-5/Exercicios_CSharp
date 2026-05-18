namespace Aula_13_Poo_Exercicio_5
{
    public abstract class ContaBancaria
    {
        public decimal Saldo { get; protected set; }
        public abstract void TipoDescricao();

        protected ContaBancaria(decimal saldo)
        {
            Saldo = saldo;
        }
    }
}