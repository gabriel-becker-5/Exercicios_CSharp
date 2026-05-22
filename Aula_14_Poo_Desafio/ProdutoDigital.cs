namespace Aula_14_Poo_Desafio
{
    public class ProdutoDigital : Produto
    {
        decimal aliquotaDesconto = 0.15m;

        public override decimal CalcularDesconto()
        {
            return Preco * aliquotaDesconto;
        }

        public ProdutoDigital(string nome, decimal preco) : base(nome, preco)
        {    
        }
        public override decimal PrecoFinalProduto()
        {
            return Preco - CalcularDesconto();
        }
    }
}