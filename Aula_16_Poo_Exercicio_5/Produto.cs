/* Encadear operações LINQ
Crie uma classe Produto com Nome (string) e Preco (double)
Crie uma List<Produto> com pelo menos 6 produtos variados
Use LINQ encadeado para:
Pegar apenas produtos com Preço > 20
Ordenar por Nome
Selecionar só o Nome
Exibir o resultado + Soma e Média dos preços de TODOS */

namespace Aula_16_Poo_Exercicio_5
{
    public class Produto
    {
        public string Nome { get; private set; }
        public double Preco { get; private set; }

        public Produto(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
        }
    }
}