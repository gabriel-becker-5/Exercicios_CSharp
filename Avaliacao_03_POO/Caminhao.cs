namespace Avaliacao_03_POO
{
    public class Caminhao : Veiculo
    {
        private int _capacidadeCarga;

        public int CapacidadeCarga
        {
            get => _capacidadeCarga;
            private set => _capacidadeCarga = value * 1000; // Conversão para Quilos
        }

        public Caminhao(string marca, string modelo, int ano, decimal precoDiaria, int capacidadeCarga)
            : base(marca, modelo, ano, precoDiaria)
        {
            CapacidadeCarga = capacidadeCarga;
        }

        public override void ExibirInformacoes()
        {
            Console.WriteLine("=== Caminhão ===");
            base.ExibirInformacoes();
            Console.WriteLine($"Capacidade de Carga: {CapacidadeCarga} kg");
        }
    }
}