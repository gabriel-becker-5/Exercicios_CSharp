namespace Aula_14_Poo_Exercicio_3
{
    public abstract class Pagamento
    {
        public decimal Valor { get; protected set; }

        public abstract string Processar();

        public Pagamento(decimal valor)
        {
            Valor = valor;
        }
    }
}