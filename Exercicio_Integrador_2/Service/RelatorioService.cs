using Exercicio_Integrador_2.Models;
using Exercicio_Integrador_2.Repository;

namespace Exercicio_Integrador_2.Service
{
    public class RelatorioService
    {
        private readonly OrdemServicoRepository _ordemServicoRepository;
        private readonly StatusOrdemServico _statusOrdemServico;
        public RelatorioService(OrdemServicoRepository ordemservicorepository,
                                StatusOrdemServico statusordemservico)
        {
            _ordemServicoRepository = ordemservicorepository;
            _statusOrdemServico = statusordemservico;
        }

        public void FaturamentoTotal()
        {
            
            Console.WriteLine();
            Console.WriteLine("=== Relatório | Faturamento Total ===");
            decimal totalFaturadoPeca = _ordemServicoRepository.ListarTodasOS()
                .Where(os => os.Status != StatusOrdemServico.Cancelada)
                .SelectMany(os => os.ListaPecas)
                .Sum(p => p.PrecoUnitario);

            decimal totalFaturadoServico = _ordemServicoRepository.ListarTodasOS()
                .Where(os => os.Status != StatusOrdemServico.Cancelada)
                .SelectMany(os => os.ListaServicos)
                .Sum(p => p.ValorBase * p.TempoEstimadoHoras);

            decimal faturamentoTotal = totalFaturadoPeca + totalFaturadoServico;

            Console.WriteLine($"Total Peças: {totalFaturadoPeca:C2}");
            Console.WriteLine($"Total Serviços: {totalFaturadoServico:C2}");
            Console.WriteLine($"Total Faturado: {faturamentoTotal:C2}");
            Console.WriteLine();
        }

        public void ServicosMaisExecutados()
        {
            Console.WriteLine();
            Console.WriteLine("=== Relatório | Serviços mais vendidos ===");
            var ServicosMaisExecutados = _ordemServicoRepository.ListarTodasOS()
                .SelectMany(os => os.ListaServicos)
                .GroupBy(p => p.Nome)
                .Select(g => new
                {
                    Servico = g.Key,
                    QtdVendas = g.Count(),
                    ValorFaturado = g.Sum(s => s.ValorBase * s.TempoEstimadoHoras)
                })
                .OrderByDescending(g => g.QtdVendas);

            foreach (var servico in ServicosMaisExecutados)
            {
                var totalFaturado = servico.QtdVendas * servico.ValorFaturado;
                Console.WriteLine($"{servico.Servico}: {servico.QtdVendas} - Faturado: {totalFaturado:C2}");
            }
            Console.WriteLine();
        }

        public void ClientesMaiorFaturamento()
        {
            Console.WriteLine();
            Console.WriteLine("=== Relatório | Top Clientes por Faturamento ===");
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

            foreach (var cliente in ClientesMaiorFaturamento)
            {
                Console.WriteLine($"{cliente.Cliente.Nome} | Peças: {cliente.Pecas:C2} | Serviços: {cliente.Servicos:C2} | Total: {cliente.TotalFaturado:C2}");
            }
            Console.WriteLine();
        }

        public void PecasMaisVendidas()
        {
            Console.WriteLine();
            Console.WriteLine("=== Relatório | Peças mais vendidas ===");
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

            foreach (var peca in PecasMaisVendidas)
            {
                Console.WriteLine($"{peca.Peca}: {peca.QtdVendas} - Faturado: {peca.ValorFaturado:C2}");
            }
            Console.WriteLine();
        }

        public void OrdensServicoEmAndamento()
        {
            Console.WriteLine();
            var OrdensServicoEmAndamento = _ordemServicoRepository.ListarTodasOS()
                                           .Where(os => os.Status == StatusOrdemServico.EmAndamento).Count();
            Console.WriteLine($"=== Relatório | OS's em andamento: {OrdensServicoEmAndamento} ===");
            Console.WriteLine();
        }
    }
}