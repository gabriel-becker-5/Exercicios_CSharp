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

        public void CadastrarPeca(string nome, string estoque, string precounitario)
        {
            int EstoqueInt;
            decimal PrecoUnitarioDecimal;
            bool EhEstoqueValido = int.TryParse(estoque, out EstoqueInt);
            bool EhPrecoUnitarioValido = decimal.TryParse(precounitario, out PrecoUnitarioDecimal);

            Peca novaPeca = new Peca(_pecaRepository.QtdPecasCriadas()+1,
                                     nome,
                                     EstoqueInt,
                                     PrecoUnitarioDecimal);

            try
            {
                _pecaRepository.CadastrarPeca(novaPeca);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }         
        }

        public void ReporEstoque(string idproduto, string qtdreposicao)
        {
            int IdProdutoInt;
            int QtdReposicaoInt;
            int.TryParse(idproduto, out IdProdutoInt);
            int.TryParse(qtdreposicao, out QtdReposicaoInt);
            Peca peca = _pecaRepository.PesquisarPecaPorID(IdProdutoInt);
            
            try
            {
                peca.ReporEstoque(peca, QtdReposicaoInt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool EhEstoqueValido(string qtdEstoqueString)
        {
            int qtdEstoque;
            bool ehValido = int.TryParse(qtdEstoqueString, out qtdEstoque);

            if (!ehValido || qtdEstoque <=0)
            {
                return false;
            }
            return true;
        }

        public bool EhPrecoUnitarioValido(string precoUnitarioString)
        {
            decimal precoUnitario;
            bool ehValido = decimal.TryParse(precoUnitarioString, out precoUnitario);

            if (!ehValido || precoUnitario <= 0)
            {
                return false;
            }
            return true;
        }

        public List<Peca> ListarPecas()
        {
            return _pecaRepository.ListarTodasPecas();
        }
    }
}