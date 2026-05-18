namespace Aula_13_Poo
{
    public class Carro : Veiculo
    {
        public int NumeroDePortas { get; private set; }

        public override void ExibirInfo()
        {
            Console.WriteLine($"Marca: {Marca}. Modelo: {Modelo}. Portas: {NumeroDePortas}");
        }

        public Carro(string marca, string modelo, int numeroPortas) : base(marca, modelo)
        {
            NumeroDePortas = numeroPortas;
        }
    }
}