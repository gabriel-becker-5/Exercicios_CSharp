// Exercício 01
// Crie 3 produtos diferentes
// Atribua valores para Nome e Preço
// Exiba todos no console

namespace Aula_11_Poo
{
    internal class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public void ExibirDadosProduto()
        {
            Console.WriteLine($"Produto: {Nome}  |  Preço: R$ {Preco}");
        }

        public int ObterPosicaoProdMaiscaro(Produto[] produtos)
        {
            int posicao = 0;
            for (int i = 1; i < produtos.Length; i++)
            {
                if (produtos[i].Preco > produtos[posicao].Preco)
                {
                    posicao = i;
                }
            }

            return posicao;
        }

    }
}