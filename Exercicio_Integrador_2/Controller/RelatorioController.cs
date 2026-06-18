using Exercicio_Integrador_2.Service;

namespace Exercicio_Integrador_2.Controller
{
    public class RelatorioController
    {
        private readonly RelatorioService _relatorioService;
        public RelatorioController(RelatorioService relatorioservice)
        {
            _relatorioService = relatorioservice;
        }

        public void FaturamentoTotal()
        {
            _relatorioService.FaturamentoTotal();
        }

        public void ServicosMaisExecutados()
        {
            _relatorioService.ServicosMaisExecutados();
        }

        public void ClientesMaiorFaturamento()
        {
            _relatorioService.ClientesMaiorFaturamento();
        }

        public void PecasMaisVendidas()
        {
            _relatorioService.PecasMaisVendidas();
        }

        public void OrdensServicoEmAndamento()
        {
            _relatorioService.OrdensServicoEmAndamento();
        }
    }
}