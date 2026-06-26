using Exercicio_Integrador_2.Models;
using Exercicio_Integrador_2.Pessoas;
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



            Console.WriteLine();
            Console.WriteLine("=== Criar nova Ordem de Serviço ===");
            Console.Write("ID do Cliente: ");
            string idDoClienteString = Console.ReadLine();







            bool ehIdValida = int.TryParse(idDoClienteString, out idDoCliente);
            Cliente clienteSelecionado = _clienteRepository.PesquisarClientePorID(idDoCliente);

            while (clienteSelecionado == null)
            {
                Console.WriteLine("Digite um ID de Cliente válido!");
                Console.Write("ID do Cliente: ");
                idDoClienteString = Console.ReadLine();
                ehIdValida = int.TryParse(idDoClienteString, out idDoCliente);
                clienteSelecionado = _clienteRepository.PesquisarClientePorID(idDoCliente);
            }

            Console.Write("Placa do Veículo: ");
            string placaDoVeiculo = Console.ReadLine();
            Veiculo veiculoSelecionado = _veiculoRepository.PesquisarVeiculoPorPlaca(placaDoVeiculo.ToUpper());

            while (veiculoSelecionado == null)
            {
                Console.WriteLine("Informe um veículo válido!");
                Console.Write("Placa do Veículo: ");
                placaDoVeiculo = Console.ReadLine();
                veiculoSelecionado = _veiculoRepository.PesquisarVeiculoPorPlaca(placaDoVeiculo.ToUpper());
            }

            Console.Write("ID do Funcionário: ");
            int idDoFuncionario;
            string idDoFuncionarioString = Console.ReadLine();
            bool ehIdFuncionarioValida = int.TryParse(idDoFuncionarioString, out idDoFuncionario);
            Funcionario funcionarioSelecionado = _funcionarioRepository.PesquisarFuncionarioPorID(idDoFuncionario);

            while (funcionarioSelecionado == null)
            {
                Console.WriteLine("Informe um ID de funcionário válido!");
                Console.Write("ID do Funcionário: ");
                idDoFuncionarioString = Console.ReadLine();
                ehIdFuncionarioValida = int.TryParse(idDoFuncionarioString, out idDoFuncionario);
                funcionarioSelecionado = funcionarioSelecionado = _funcionarioRepository.PesquisarFuncionarioPorID(idDoFuncionario);
            }

            string maisServicos = "";
            int idDoServico;
            List<Servico> ServicosSelecionados = [];

            while (maisServicos.ToUpper() != "N")
            {
                Console.Write("ID do Serviço: ");
                string idDoServicoString = Console.ReadLine();
                bool ehIdServicoValida = int.TryParse(idDoServicoString, out idDoServico);
                Servico servicoParaAddOS = _servicoRepository.PesquisarServicoPorID(idDoServico);

                while (servicoParaAddOS == null)
                {
                    Console.WriteLine("Informe um ID de Serviço válido!");
                    Console.Write("ID do Serviço: ");
                    idDoServicoString = Console.ReadLine();
                    ehIdServicoValida = int.TryParse(idDoServicoString, out idDoServico);
                    servicoParaAddOS = _servicoRepository.PesquisarServicoPorID(idDoServico);
                }

                ServicosSelecionados.Add(servicoParaAddOS);
                maisServicos = "";
                Console.Write("Há mais Serviços para adicionar? (S/N): ");
                maisServicos = Console.ReadLine();
                while (maisServicos.ToUpper() != "S" && maisServicos.ToUpper() != "N")
                {
                    Console.WriteLine("Opção inválida!");
                    Console.Write("Há mais Serviços para adicionar? (S/N): ");
                    maisServicos = Console.ReadLine();
                }
            }

            string maisPecas = "";
            int idDaPeca;
            List<Peca> PecasSelecionadas = [];

            while (maisPecas.ToUpper() != "N")
            {
                Console.Write("ID da Peça: ");
                string idDaPecaString = Console.ReadLine();
                bool ehIdPecaValida = int.TryParse(idDaPecaString, out idDaPeca);
                Peca pecasParaAddOS = _pecaRepository.PesquisarPecaPorID(idDaPeca);

                while (pecasParaAddOS == null)
                {
                    Console.WriteLine("Digite um ID de Peça válido!");
                    Console.Write("ID da Peça: ");
                    idDaPecaString = Console.ReadLine();
                    ehIdPecaValida = int.TryParse(idDaPecaString, out idDaPeca);
                    pecasParaAddOS = _pecaRepository.PesquisarPecaPorID(idDaPeca);
                }

                PecasSelecionadas.Add(pecasParaAddOS);

                maisPecas = "";
                Console.Write("Há mais Peças para adicionar? (S/N): ");
                maisPecas = Console.ReadLine();
                while (maisPecas.ToUpper() != "S" && maisPecas.ToUpper() != "N")
                {
                    Console.WriteLine("Opção inválida!");
                    Console.Write("Há mais Peças para adicionar? (S/N): ");
                    maisPecas = Console.ReadLine();
                }
            }

            Console.WriteLine("A - Aberta  |  P - Aguardando Peças  |  E - Em Andamento  |  F - Finalizada  |  C - Cancelada");
            Console.Write("Status da Ordem de Serviço: ");
            string statusOrdemServicoString = Console.ReadLine();
            StatusOrdemServico statusOrdem = StatusOrdemServico.Aberta;

            while (statusOrdemServicoString.ToUpper() != "A" && statusOrdemServicoString.ToUpper() != "P"
                && statusOrdemServicoString.ToUpper() != "E" && statusOrdemServicoString.ToUpper() != "F"
                && statusOrdemServicoString.ToUpper() != "C")
            {
                Console.WriteLine("Informe um status válido.");
                Console.WriteLine("A - Aberta  |  P - Aguardando Peças  |  E - Em Andamento  |  F - Finalizada  |  C - Cancelada");
                Console.Write("Status da Ordem de Serviço: ");
                statusOrdemServicoString = Console.ReadLine();
            }

            switch (statusOrdemServicoString.ToUpper())
            {
                case "A":
                    statusOrdem = StatusOrdemServico.Aberta;
                    break;
                case "P":
                    statusOrdem = StatusOrdemServico.AguardaPecas;
                    break;
                case "E":
                    statusOrdem = StatusOrdemServico.EmAndamento;
                    break;
                case "F":
                    statusOrdem = StatusOrdemServico.Finalizada;
                    break;
                case "C":
                    statusOrdem = StatusOrdemServico.Cancelada;
                    break;
                default:
                    break;
            }

            OrdemServico novaOrdemDeServico = new OrdemServico(_osRepository.QtdOrdensServicoCriadas() + 1,
                                                               clienteSelecionado,
                                                               veiculoSelecionado,
                                                               funcionarioSelecionado,
                                                               ServicosSelecionados,
                                                               PecasSelecionadas,
                                                               DateTime.UtcNow,
                                                               statusOrdem);

            _osRepository.CadastrarOS(novaOrdemDeServico);
            Console.WriteLine("Ordem de Serviço criada com sucesso.");
            Console.WriteLine();









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