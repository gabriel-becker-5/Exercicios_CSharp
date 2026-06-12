/* Classe Peça - Representa um item do estoque.
Atributos: Id, Nome, Quantidade, PrecoUnitario
Métodos: BaixarEstoque(), ReporEstoque() */

namespace Exercicio_Integrador_2.Modulos
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
    }
}