namespace Avaliacao_03_POO
{
    public class Carro : Veiculo
    {
        private int _quantidadePortas;

        public int QuantidadePortas
        {
            get => _quantidadePortas;
            private set => _quantidadePortas = value;
        }

        public Carro(string marca, string modelo, int ano, decimal precoDiaria, int quantidadePortas)
            : base(marca, modelo, ano, precoDiaria)
        {
            QuantidadePortas = quantidadePortas;
        }

        public override void ExibirInformacoes()
        {
            Console.WriteLine("=== Carro ===");
            base.ExibirInformacoes();
            Console.WriteLine($"Quantidade de Portas: {QuantidadePortas}");
        }
    }
}