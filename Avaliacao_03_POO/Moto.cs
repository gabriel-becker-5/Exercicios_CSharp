namespace Avaliacao_03_POO
{
    public class Moto : Veiculo
    {
        private int _cilindrada;

        public int Cilindrada { get => _cilindrada; private set => _cilindrada = value; }

        public Moto(string marca, string modelo, int ano, decimal precoDiaria, int cilindrada)
            : base(marca, modelo, ano, precoDiaria)
        {
            Cilindrada = cilindrada;
        }
        public override void ExibirInformacoes()
        {
            Console.WriteLine("=== Moto ===");
            base.ExibirInformacoes();
            Console.WriteLine($"Cilindrada: {Cilindrada}");
        }
    }
}