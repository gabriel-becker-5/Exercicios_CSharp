using Exercicio_Integrador_2.Models;
using Exercicio_Integrador_2.Repository;

namespace Exercicio_Integrador_2.Service
{
    public class RelatorioService
    {
        private readonly OrdemServicoRepository _ordemServicoRepository;
        public RelatorioService(OrdemServicoRepository ordemservicorepository,
                                StatusOrdemServico statusordemservico)
        {
            _ordemServicoRepository = ordemservicorepository;
        }

        public decimal FaturamentoTotal()
        {
            decimal totalFaturadoPeca = _ordemServicoRepository.ListarTodasOS()
                .Where(os => os.Status != StatusOrdemServico.Cancelada)
                .SelectMany(os => os.ListaPecas)
                .Sum(p => p.PrecoUnitario);

            decimal totalFaturadoServico = _ordemServicoRepository.ListarTodasOS()
                .Where(os => os.Status != StatusOrdemServico.Cancelada)
                .SelectMany(os => os.ListaServicos)
                .Sum(p => p.ValorBase * p.TempoEstimadoHoras);

            decimal faturamentoTotal = totalFaturadoPeca + totalFaturadoServico;
            return faturamentoTotal;
        }

        public IEnumerable<dynamic> ServicosMaisExecutados()
        {
            var ServicosMaisExecutados = _ordemServicoRepository.ListarTodasOS()
                .SelectMany(os => os.ListaServicos)
                .GroupBy(p => p.Nome)
                .Select(g => new
                {
                    Servico = g.Key,
                    QtdVendas = g.Count(),
                    ValorFaturado = g.Sum(s => (s.ValorBase * s.TempoEstimadoHoras) * g.Count())
                })
                .OrderByDescending(g => g.ValorFaturado);
            return ServicosMaisExecutados;
        }

        public IEnumerable<dynamic> ClientesMaiorFaturamento()
        {
            var ClientesMaiorFaturamento = _ordemServicoRepository.ListarTodasOS()
                .GroupBy(os => os.Cliente)
                .Select(g => new
                {
                    Cliente = g.Key,
                    Pecas = g
                    .SelectMany(os => os.ListaPecas)
                    .Sum(p => p.PrecoUnitario),

                    Servicos = g
                    .SelectMany(os => os.ListaServicos)
                    .Sum(s => s.TempoEstimadoHoras * s.ValorBase),

                    TotalFaturado = g.SelectMany(os => os.ListaPecas)
                    .Sum(p => p.PrecoUnitario) +
                    g.SelectMany(os => os.ListaServicos)
                    .Sum(s => s.TempoEstimadoHoras * s.ValorBase)
                })
                .OrderByDescending(o => o.TotalFaturado);

            return ClientesMaiorFaturamento;
        }

        public IEnumerable<dynamic> PecasMaisVendidas()
        {
            var PecasMaisVendidas = _ordemServicoRepository.ListarTodasOS()
                .SelectMany(os => os.ListaPecas)
                .GroupBy(p => p.Nome)
                .Select(g => new
                {
                    Peca = g.Key,
                    QtdVendas = g.Count(),
                    ValorFaturado = g.Sum(s => s.PrecoUnitario)
                })
                .OrderByDescending(g => g.QtdVendas);

            return PecasMaisVendidas;
        }

        public int OrdensServicoEmAndamento()
        {
            return _ordemServicoRepository.ListarTodasOS().Where(os => os.Status == StatusOrdemServico.EmAndamento).Count();
        }
    }
}