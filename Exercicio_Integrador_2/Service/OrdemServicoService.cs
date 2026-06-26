using Exercicio_Integrador_2.Interfaces;
using Exercicio_Integrador_2.Models;
using Exercicio_Integrador_2.Pessoas;
using Exercicio_Integrador_2.Repository;

namespace Exercicio_Integrador_2.Service
{
    public class OrdemServicoService
    {
        private readonly OrdemServicoRepository _osRepository;
        private readonly ClienteRepository _clienteRepository;

        public OrdemServicoService(OrdemServicoRepository osrepository)
        {
            _osRepository = osrepository;
        }

        public void CriarOrdemServico()
        {
            Console.WriteLine();
            Console.WriteLine("=== Criar nova Ordem de Serviço ===");
            int idDoCliente;
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

            OrdemServico novaOrdemDeServico = new OrdemServico(_osRepository.QtdOrdensServicoCriadas()+1, 
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


        public bool CadastroClienteEhValido(string idClienteString)
        {
            int idCliente;
            bool ehIdValida = int.TryParse(idClienteString, out idCliente);
            Cliente clienteSelecionado = _clienteRepository.PesquisarClientePorID(idCliente);
            if (clienteSelecionado == null || ehIdValida == false)
            {
                return false;
            }
            return true;
        }





        public void AdicionarServicoNaOS()
        {
            Console.WriteLine("=== Adicionar um Serviço à O.S. ===");
            string desejaAddMaisServicos = "";
            int idServicoAdicionar;
            List<Servico> ServicosParaAdicionar = [];

            Console.Write("Número da Ordem de Serviço: ");
            string ordemDeServicoString = Console.ReadLine();
            int ordemDeServicoAdicionar;
            bool ehNroOrdemServicoValida = int.TryParse(ordemDeServicoString, out ordemDeServicoAdicionar);
            OrdemServico OSadicionar = _osRepository.PesquisarOSporID(ordemDeServicoAdicionar);

            while (OSadicionar == null)
            {
                Console.WriteLine("Informe uma Ordem de Serviço válida!");
                Console.Write("Número da Ordem de Serviço: ");
                ordemDeServicoString = Console.ReadLine();
                ehNroOrdemServicoValida = int.TryParse(ordemDeServicoString, out ordemDeServicoAdicionar);
                OSadicionar = _osRepository.PesquisarOSporID(ordemDeServicoAdicionar);
            }

            while (desejaAddMaisServicos.ToUpper() != "N")
            {
                Console.Write("ID do Serviço: ");
                string idServicoAdicionarString = Console.ReadLine();
                bool ehIdServicoValida = int.TryParse(idServicoAdicionarString, out idServicoAdicionar);
                Servico servicoParaAddOS = _servicoRepository.PesquisarServicoPorID(idServicoAdicionar);

                while (servicoParaAddOS == null)
                {
                    Console.WriteLine("Informe um ID de Serviço válido!");
                    Console.Write("ID do Serviço: ");
                    idServicoAdicionarString = Console.ReadLine();
                    ehIdServicoValida = int.TryParse(idServicoAdicionarString, out idServicoAdicionar);
                    servicoParaAddOS = _servicoRepository.PesquisarServicoPorID(idServicoAdicionar);
                }

                ServicosParaAdicionar.Add(servicoParaAddOS);
                desejaAddMaisServicos = "";

                Console.Write("Há mais Serviços para adicionar? (S/N): ");
                desejaAddMaisServicos = Console.ReadLine();
                while (desejaAddMaisServicos.ToUpper() != "S" && desejaAddMaisServicos.ToUpper() != "N")
                {
                    Console.WriteLine("Opção inválida!");
                    Console.Write("Há mais Serviços para adicionar? (S/N): ");
                    desejaAddMaisServicos = Console.ReadLine();
                }
            }

            foreach (Servico servicoParaAdicionar in ServicosParaAdicionar)
            {
                OSadicionar.ListaServicos.Add(servicoParaAdicionar);
            }
            Console.WriteLine("Serviço(s) adicionado(s) com sucesso.");
            Console.WriteLine();
        }

        public void AdicionarPecaNaOS()
        {
            Console.WriteLine("=== Adicionar Peça à uma O.S. ===");
            string desejaAddMaisPecas = "";
            int idPecaAdicionar;
            List<Peca> PecasParaAdicionar = [];

            Console.Write("Número da Ordem de Serviço: ");
            string ordemDeServicoString = Console.ReadLine();
            int ordemDeServicoAdicionar = 0;
            bool ehNroOrdemServicoValida = int.TryParse(ordemDeServicoString, out ordemDeServicoAdicionar);
            OrdemServico OSadicionar = _osRepository.PesquisarOSporID(ordemDeServicoAdicionar);

            while (OSadicionar == null)
            {
                Console.WriteLine("Informe uma Ordem de Serviço válida!");
                Console.Write("Número da Ordem de Serviço: ");
                ordemDeServicoString = Console.ReadLine();
                ehNroOrdemServicoValida = int.TryParse(ordemDeServicoString, out ordemDeServicoAdicionar);
                OSadicionar = _osRepository.PesquisarOSporID(ordemDeServicoAdicionar);
            }

            string maisPecas = "";
            int idDaPeca = 0;
            List<Peca> PecasSelecionadas = [];

            while (maisPecas.ToUpper() != "N")
            {
                Console.Write("ID da Peça: ");
                string idDaPecaString = Console.ReadLine();
                bool ehIdPecaValida = int.TryParse(idDaPecaString, out idDaPeca);
                Peca pecasParaAddOS = _pecaRepository.PesquisarPecaPorID(idDaPeca);

                while (pecasParaAddOS == null)
                {
                    Console.WriteLine("Informe um ID de Peça válido!");
                    Console.Write("ID da Peça: ");
                    idDaPecaString = Console.ReadLine();
                    ehIdPecaValida = int.TryParse(idDaPecaString, out idDaPeca);
                    pecasParaAddOS = _pecaRepository.PesquisarPecaPorID(idDaPeca);
                }

                PecasParaAdicionar.Add(pecasParaAddOS);

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

            foreach (Peca pecaParaAdicionar in PecasParaAdicionar)
            {
                OSadicionar.ListaPecas.Add(pecaParaAdicionar);
            }
            Console.WriteLine("Peça(s) adicionada(s) com sucesso.");
            Console.WriteLine();
        }

        public void FinalizarOS()
        {
            Console.WriteLine("=== Fechar Ordem de Serviço ===");
            Console.Write("Número da Ordem de Serviço: ");
            string ordemDeServicoString = Console.ReadLine();
            int ordemDeServicoEmEdicao = 0;
            bool ehNroOrdemServicoValida = int.TryParse(ordemDeServicoString, out ordemDeServicoEmEdicao);
            OrdemServico OrdemDeServicoEmEdicao = _osRepository.PesquisarOSporID(ordemDeServicoEmEdicao);

            while (OrdemDeServicoEmEdicao == null)
            {
                Console.WriteLine("Informe uma Ordem de Serviço válida!");
                Console.Write("Número da Ordem de Serviço: ");
                ordemDeServicoString = Console.ReadLine();
                ehNroOrdemServicoValida = int.TryParse(ordemDeServicoString, out ordemDeServicoEmEdicao);
                OrdemDeServicoEmEdicao = _osRepository.PesquisarOSporID(ordemDeServicoEmEdicao);
            }

            OrdemDeServicoEmEdicao.FinalizarOrdemServico();
            Console.WriteLine($"Ordem de Serviço nº {ordemDeServicoEmEdicao} foi finalizada com sucesso.");

            NotificacaoWPP notificacao = new NotificacaoWPP();
            string mensagem = $"Olá, {OrdemDeServicoEmEdicao.Cliente.Nome}, tudo bem? Estamos passando para avisa-lo que os reparos no seu veículo {OrdemDeServicoEmEdicao.Veiculo.Marca} {OrdemDeServicoEmEdicao.Veiculo.Modelo} foram concluídos.";
            notificacao.ConclusaoOrdemDeServicoAsync(mensagem);

            Console.WriteLine();
        }

        public void CancelarOS()
        {
            Console.WriteLine("=== Cancelar Ordem de Serviço ===");
            Console.Write("Número da Ordem de Serviço: ");
            string ordemDeServicoString = Console.ReadLine();
            int ordemDeServicoEmEdicao = 0;
            bool ehNroOrdemServicoValida = int.TryParse(ordemDeServicoString, out ordemDeServicoEmEdicao);
            OrdemServico OrdemDeServicoEmEdicao = _osRepository.PesquisarOSporID(ordemDeServicoEmEdicao);

            while (OrdemDeServicoEmEdicao == null)
            {
                Console.WriteLine("Informe uma Ordem de Serviço válida!");
                Console.Write("Número da Ordem de Serviço: ");
                ordemDeServicoString = Console.ReadLine();
                ehNroOrdemServicoValida = int.TryParse(ordemDeServicoString, out ordemDeServicoEmEdicao);
                OrdemDeServicoEmEdicao = _osRepository.PesquisarOSporID(ordemDeServicoEmEdicao);
            }

            OrdemDeServicoEmEdicao.CancelarOrdemServico();
            Console.WriteLine($"Ordem de Serviço nº {ordemDeServicoEmEdicao} foi cancelada.");
            Console.WriteLine();
        }

        public void ListarOrdensServicos()
        {
            Console.WriteLine("=== Listar Ordens de Serviço ===");
            List<OrdemServico> listaOrdensServico = _osRepository.ListarTodasOS();
            foreach (OrdemServico os in listaOrdensServico)
            {
                Console.WriteLine();
                Console.WriteLine(os.DetalharOrdemServico());
            }
            Console.WriteLine();
        }
    }
}