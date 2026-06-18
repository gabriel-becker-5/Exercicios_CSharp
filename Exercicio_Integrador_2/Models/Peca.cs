namespace Exercicio_Integrador_2.Models
{
    public class Peca
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int QtdEstoque { get; private set; }
        public decimal PrecoUnitario { get; private set; }

        public Peca(int id, string nome, int qtdestoque, decimal precounitario)
        {
            Id = id;
            Nome = nome;
            QtdEstoque = qtdestoque;
            PrecoUnitario = precounitario;
        }

        public void BaixarEstoque(Peca peca, int qtdParaBaixarEstoque) 
        {
            peca.QtdEstoque -= qtdParaBaixarEstoque;
        }

        public void ReporEstoque(Peca peca, int qtdParaSubirEstoque) 
        {
            peca.QtdEstoque += qtdParaSubirEstoque;
        }

        public void DetalharPeca()
        {
            Console.WriteLine($"ID: {Id} | Descrição: {Nome} | Estoque: {QtdEstoque} | Valor unitário: {PrecoUnitario:C2}");
        }
    }
}