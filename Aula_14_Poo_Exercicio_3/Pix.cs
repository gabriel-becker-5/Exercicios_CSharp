namespace Aula_14_Poo_Exercicio_3
{
    internal class Pix : Pagamento
    {
        public override string Processar()
        {
            return $"Pagamento de R$ {Valor} | Pix";
        }

        public Pix(decimal valor) : base(valor)
        {
        }
    }
}