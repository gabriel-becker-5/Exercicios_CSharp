namespace Avaliacao_03_POO
{
    public abstract class Veiculo
    {
        private string _marca;
        private string _modelo;
        private int _ano;
        private decimal _precoDiaria;

        public string Marca { get => _marca; private set => _marca = value; }
        public string Modelo { get => _modelo; private set => _modelo = value; }
        public int Ano { get => _ano; private set => _ano = value; }
        public decimal PrecoDiaria { get => _precoDiaria; private set => _precoDiaria = value; }

        public Veiculo(string marca, string modelo, int ano, decimal precoDiaria)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            PrecoDiaria = precoDiaria;
        }
        public virtual void ExibirInformacoes()
        {
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Ano: {Ano}");
            Console.WriteLine($"Preço Diária: {PrecoDiaria:C2}");
        }

        public decimal CalcularLocacao(int diasLocacao)
        {
            return diasLocacao * PrecoDiaria;
        }
    }
}