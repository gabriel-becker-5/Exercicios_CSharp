namespace Aula_14_Poo_Exercicio_3
{
    public class CartaoCredito : Pagamento
    {
        public override string Processar()
        {
            return $"Pagamento de R$ {Valor} | Cartão de Crédito";
        }

        public CartaoCredito(decimal valor) : base(valor)
        {
        }
    }
}