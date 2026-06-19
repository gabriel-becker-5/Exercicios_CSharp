using Exercicio_Integrador_2.Models;
using Exercicio_Integrador_2.Repository;

namespace Exercicio_Integrador_2.Service
{
    public class PecaService
    {
        private readonly PecaRepository _pecaRepository;

        public PecaService(PecaRepository pecarepository)
        {
            _pecaRepository = pecarepository;
        }

        public void CadastrarPeca()
        {
            Console.WriteLine("=== Cadastrar Peça ===");

            Console.Write("Descrição: ");
            string nomePeca = Console.ReadLine();

            Console.Write("Estoque Disponível: ");
            string estoqueDisponivelString = Console.ReadLine();
            int estoqueDisponivel;
            bool ehEstoqueDisponivelValido = int.TryParse(estoqueDisponivelString, out estoqueDisponivel);

            while (!ehEstoqueDisponivelValido || estoqueDisponivel <= 0)
            {
                Console.WriteLine("Digite um número válido!");
                Console.Write("Estoque Disponível: ");
                estoqueDisponivelString = Console.ReadLine();
                ehEstoqueDisponivelValido = int.TryParse(estoqueDisponivelString, out estoqueDisponivel);
            }

            Console.Write("Preço Unitário R$: ");
            string precoUnitarioString = Console.ReadLine();
            decimal precoUnitario;
            bool ehPrecoUnitarioValido = decimal.TryParse(precoUnitarioString, out precoUnitario);

            while (!ehPrecoUnitarioValido || precoUnitario <= 0)
            {
                Console.WriteLine("Digite um número válido!");
                Console.Write("Preço Unitário R$: ");
                precoUnitarioString = Console.ReadLine();
                ehPrecoUnitarioValido = decimal.TryParse(precoUnitarioString, out precoUnitario);
            }

            Peca novaPeca = new Peca(_pecaRepository.QtdPecasCriadas()+1, nomePeca, estoqueDisponivel, precoUnitario);
            _pecaRepository.CadastrarPeca(novaPeca);
            Console.WriteLine("Peça cadastrada com sucesso.");
            Console.WriteLine();
        }

        public void ReporEstoque()
        {
            Console.WriteLine();
            Console.WriteLine("=== Reposição de Estoque ===");
            Console.Write("Informe o ID do Produto: ");
            string idProdutoString = Console.ReadLine();
            int idProduto;
            bool ehIDProdutoValido = int.TryParse(idProdutoString, out idProduto);

            while (!ehIDProdutoValido || idProduto <= 0)
            {
                Console.WriteLine("Digite um número válido!");
                Console.Write("Informe o ID do Produto: ");
                idProdutoString = Console.ReadLine();
                ehIDProdutoValido = int.TryParse(idProdutoString, out idProduto);
            }

            Console.Write("Quantidade para repor: ");
            string qtdReposicaoString = Console.ReadLine();
            int qtdReposicao;
            bool ehQtdReposicaoValida = int.TryParse(qtdReposicaoString, out qtdReposicao);

            while (!ehQtdReposicaoValida || qtdReposicao <= 0)
            {
                Console.WriteLine("Digite um número válido!");
                Console.Write("Quantidade para repor: ");
                qtdReposicaoString = Console.ReadLine();
                ehQtdReposicaoValida = int.TryParse(qtdReposicaoString, out qtdReposicao);
            }

            Peca pecaReposicao = _pecaRepository.PesquisarPecaPorID(idProduto);
            string nome_Peca = pecaReposicao.Nome;
            pecaReposicao.ReporEstoque(pecaReposicao, qtdReposicao);
            Console.WriteLine($"Incluído {qtdReposicao} unidades de estoque para o produto {nome_Peca}.");
            Console.WriteLine();
        }

        public void ListarPecas()
        {
            Console.WriteLine("=== Visualização do Estoque ===");
            List<Peca> listaPecas = _pecaRepository.ListarTodasPecas();
            foreach (Peca peca in listaPecas)
            {
                Console.WriteLine(peca.DetalharPeca());
            }
            Console.WriteLine();
        }
    }
}