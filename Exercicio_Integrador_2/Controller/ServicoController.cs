using Exercicio_Integrador_2.Service;

namespace Exercicio_Integrador_2.Controller
{
    public class ServicoController
    {
        private readonly ServicoService _servicoService;

        public ServicoController(ServicoService servicoservice)
        {
            _servicoService = servicoservice;
        }

        public void CadastrarServico()
        {
            _servicoService.CadastrarServico();
        }

        public void ListarServicos()
        {
            _servicoService.ListarServicos();
        }
    }
}