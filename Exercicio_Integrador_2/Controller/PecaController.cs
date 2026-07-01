using Exercicio_Integrador_2.Models;
using Exercicio_Integrador_2.Service;

namespace Exercicio_Integrador_2.Controller
{
    public class PecaController
    {
        private readonly PecaService _pecaService;

        public PecaController(PecaService pecaservice)
        {
            _pecaService = pecaservice;
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

            try
            {
                _pecaService.CadastrarPeca(nomePeca, estoqueDisponivelString, precoUnitarioString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

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

            try
            {
                _pecaService.ReporEstoque(idProdutoString, qtdReposicaoString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                       
            Console.WriteLine($"Estoque atualizado com sucesso.");
            Console.WriteLine();
        }

        public void ListarPecas()
        {
            Console.WriteLine("=== Visualização do Estoque ===");
            List<Peca> listaPecas = _pecaService.ListarPecas();
            foreach (Peca peca in listaPecas)
            {
                Console.WriteLine(peca.DetalharPeca());
            }
            Console.WriteLine();
        }
    }
}