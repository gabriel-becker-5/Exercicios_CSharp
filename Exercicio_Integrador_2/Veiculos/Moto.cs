/* Classe Abstrata Veiculo
Atributos: Placa, Marca, Modelo, Ano
Métodos: CalcularTaxaServico()
- Classe Carro - Herda de Veiculo.
- Classe Moto - Herda de Veiculo.
- Classe Caminhao - Herda de Veiculo.
Cada tipo de veículo deve possuir comportamento próprio para cálculo da taxa de serviço. */

namespace Exercicio_Integrador_2.Veiculos
{
    public class Moto : Veiculo
    {
        public const decimal TAXA_SERVICO = 0.02m;

        public Moto(string placa, string marca, string modelo, int anofabricacao) : 
            base(placa, marca, modelo, anofabricacao)
        {
        }

        public override decimal TaxaServico(decimal ValorTotalOS)
        {
            return ValorTotalOS * TAXA_SERVICO;
        }
    }
}