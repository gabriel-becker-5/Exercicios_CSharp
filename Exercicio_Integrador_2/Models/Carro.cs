namespace Exercicio_Integrador_2.Models
{
    public class Carro : Veiculo
    {
        public const decimal TAXA_SERVICO = 0.03m;

        public Carro(string placa, string marca, string modelo, int anofabricacao) : base(placa, marca, modelo, anofabricacao)
        {
        }

        public override decimal TaxaServico(decimal ValorTotalOS)
        {
            return ValorTotalOS * TAXA_SERVICO;
        }
    }
}