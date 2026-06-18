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
            _pecaService.CadastrarPeca();
        }

        public void ReporEstoque()
        {
            _pecaService.ReporEstoque();
        }

        public void ListarPecas()
        {
            _pecaService.ListarPecas();
        }
    }
}