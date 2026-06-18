namespace Exercicio_Integrador_2.Models
{
    public class Caminhao : Veiculo
    {
        public const decimal TAXA_SERVICO = 0.04m;
        public Caminhao(string placa, string marca, string modelo, int anofabricacao) : base(placa, marca, modelo, anofabricacao)
        {
        }

        public override decimal TaxaServico(decimal ValorTotalOS)
        {
            return ValorTotalOS * TAXA_SERVICO;
        }
    }
}