// Crie classe Veículo com atributos marca e modelo
// Método ExibirInfo() que exibe marca e modelo
// Crie a classe Carro que herda de Veiculo
// Adicione a propriedade NumeroDePortas
// Crie um Objeto Carro e exiba todas as infos.

namespace Aula_13_Poo
{
    public class Veiculo
    {
        public string marca {  get; set; }
        public string modelo { get; set; }

        public virtual void ExibirInfo()
        {
            Console.WriteLine($"Marca: {marca}. Modelo: {modelo}");
        }
    }
}