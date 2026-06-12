/* Classe Abstrata Veiculo
Atributos: Placa, Marca, Modelo, Ano
Métodos: CalcularTaxaServico()
- Classe Carro - Herda de Veiculo.
- Classe Moto - Herda de Veiculo.
- Classe Caminhao - Herda de Veiculo.
Cada tipo de veículo deve possuir comportamento próprio para cálculo da taxa de serviço. */

namespace Exercicio_Integrador_2.Veiculos
{
    public abstract class Veiculo
    {
        public string Placa { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int AnoFabricacao { get; private set; }

        public Veiculo(string placa, string marca, string modelo, int anofabricacao)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            AnoFabricacao = anofabricacao;
        }

        abstract public decimal TaxaServico(decimal ValorTotalOS);

        virtual public string ApresentarDadosVeiculo()
        {
            return $"Placa: {Placa} | Marca: {Marca} | Modelo: {Modelo} | Ano de Fabricação: {AnoFabricacao}";
        }
    }
}