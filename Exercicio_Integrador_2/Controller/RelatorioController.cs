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
            Console.WriteLine();
            Console.WriteLine("=== Relatório | Faturamento Total ===");
            Console.WriteLine($"Total Faturado: {_relatorioService.FaturamentoTotal():C2}");
            Console.WriteLine();
        }

        public void ServicosMaisExecutados()
        {
            Console.WriteLine();
            Console.WriteLine("=== Relatório | Serviços mais vendidos ===");
            foreach (var servico in _relatorioService.ServicosMaisExecutados())
            {
                Console.WriteLine($"{servico.Servico}: {servico.QtdVendas} - Faturado: {servico.ValorFaturado:C2}");
            }
            Console.WriteLine();
        }

        public void ClientesMaiorFaturamento()
        {
            Console.WriteLine();
            Console.WriteLine("=== Relatório | Top Clientes por Faturamento ===");
            foreach (var cliente in _relatorioService.ClientesMaiorFaturamento())
            {
                Console.WriteLine($"{cliente.Cliente.Nome} | Peças: {cliente.Pecas:C2} | Serviços: {cliente.Servicos:C2} | Total: {cliente.TotalFaturado:C2}");
            }
            Console.WriteLine();
        }

        public void PecasMaisVendidas()
        {
            Console.WriteLine();
            Console.WriteLine("=== Relatório | Peças mais vendidas ===");
            foreach (var peca in _relatorioService.PecasMaisVendidas())
            {
                Console.WriteLine($"{peca.Peca}: {peca.QtdVendas} - Faturado: {peca.ValorFaturado:C2}");
            }
            Console.WriteLine();
        }

        public void OrdensServicoEmAndamento()
        {
            Console.WriteLine();
            Console.WriteLine($"=== Relatório | OS's em andamento: {_relatorioService.OrdensServicoEmAndamento()} ===");
            Console.WriteLine();
        }
    }
}