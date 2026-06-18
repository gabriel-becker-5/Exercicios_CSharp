namespace Exercicio_Integrador_2.Models
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
            return $"Placa: {Placa} | Marca: {Marca} | Modelo: {Modelo} | Ano de Fabricação: {AnoFabricacao} | Tipo de Veículo: {GetType().Name}";
        }
    }
}