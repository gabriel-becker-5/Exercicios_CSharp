namespace Aula_15_Poo_Exercicio_2
{
    internal class Produto : IDescricao, ICalculavel
    {
        public string Descricao { get; private set; }
        public double Preco {  get; private set; }
        const double DESCONTO_A_VISTA = 0.1;

        public string Descrever()
        {
            return Descricao;
        }

        public double Calcular()
        {
            return Preco - (Preco * DESCONTO_A_VISTA);
        }

        public Produto(string descricao, double preco)
        {
            Descricao = descricao;
            Preco = preco;
        }
    }
}