namespace Aula_14_Poo_Desafio
{
    public class ProdutoFisico : Produto
    {
        decimal aliquotaDesconto = 0.05m;
        decimal freteValor = 15m;

        public override decimal CalcularDesconto()
        {
            return Preco * aliquotaDesconto;
        }

        public override decimal PrecoFinalProduto()
        {
            return Preco - CalcularDesconto() + freteValor;
        }

        public ProdutoFisico(string nome, decimal preco) : base(nome, preco)
        {
        }
    }
}