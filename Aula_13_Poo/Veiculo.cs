namespace Aula_13_Poo
{
    public abstract class Veiculo
    {
        public string Marca {  get; private set; }
        public string Modelo { get; private set; }

        public abstract void ExibirInfo();

        public Veiculo(string marca, string modelo)
        {
            Marca = marca;
            Modelo = modelo;
        }
    }
}