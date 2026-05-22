namespace Aula_14_Poo_Desafio
{
    public class ProdutoAssinatura : Produto
    {
        decimal aliquotaDesconto = 0.25m;
        decimal mensalidadeValor = 9.90m;

        public override decimal CalcularDesconto()
        {
            return Preco * aliquotaDesconto;
        }

        public override decimal PrecoFinalProduto()
        {
            return Preco - CalcularDesconto() + mensalidadeValor;
        }

        public ProdutoAssinatura(string nome, decimal preco) : base(nome, preco)
        {
            
        }
    }
}