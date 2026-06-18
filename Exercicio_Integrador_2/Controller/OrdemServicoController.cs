using Exercicio_Integrador_2.Service;

namespace Exercicio_Integrador_2.Controller
{
    public class OrdemServicoController
    {
        private readonly OrdemServicoService _ordemServicoService;

        public OrdemServicoController(OrdemServicoService ordemservicoservice)
        {
            _ordemServicoService = ordemservicoservice;
        }

        public void CriarOS()
        {
            _ordemServicoService.CriarOrdemServico();
        }

        public void AdicionarServicoNaOS()
        {
            _ordemServicoService.AdicionarServicoNaOS();
        }

        public void AdicionarPecaNaOS()
        {
            _ordemServicoService.AdicionarPecaNaOS();
        }

        public void FinalizarOS()
        {
            _ordemServicoService.FinalizarOS();
        }

        public void CancelarOS()
        {
            _ordemServicoService.CancelarOS();
        }

        public void ListarOrdensDeServico()
        {
            _ordemServicoService.ListarOrdensServicos();
        }
    }
}