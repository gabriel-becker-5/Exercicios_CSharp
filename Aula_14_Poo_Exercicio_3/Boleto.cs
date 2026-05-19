namespace Aula_14_Poo_Exercicio_3
{
    internal class Boleto : Pagamento
    {
        public override string Processar()
        {
            return $"Boleto de R$ {Valor} gerado com vencimento em 3 dias";
        }

        public Boleto(decimal valor) : base(valor)
        {
        }
    }
}