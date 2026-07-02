using Exercicio_Integrador_2.Interfaces;
using Exercicio_Integrador_2.Models;
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

        public void CriarOrdemServico()
        {
            Console.WriteLine();
            Console.WriteLine("=== Criar nova Ordem de Serviço ===");
            Console.Write("ID do Cliente: ");
            string idDoClienteString = Console.ReadLine();
            bool verificaCliente = _ordemServicoService.CadastroClienteEhValido(idDoClienteString);

            while (!verificaCliente)
            {
                Console.WriteLine("Informe uma ID válida!");
                Console.Write("ID do Cliente: ");
                idDoClienteString = Console.ReadLine();
                verificaCliente = _ordemServicoService.CadastroClienteEhValido(idDoClienteString);
            }

            Console.Write("Placa do Veículo: ");
            string placaDoVeiculo = Console.ReadLine();
            bool verificaPlaca = _ordemServicoService.PlacaEhValida(placaDoVeiculo);

            while (!verificaPlaca)
            {
                Console.WriteLine("Informe um veículo válido!");
                Console.Write("Placa do Veículo: ");
                placaDoVeiculo = Console.ReadLine();
                verificaPlaca = _ordemServicoService.PlacaEhValida(placaDoVeiculo);
            }

            Console.Write("ID do Funcionário: ");
            string idDoFuncionarioString = Console.ReadLine();
            bool verificaFuncionario = _ordemServicoService.FuncionarioEhValido(idDoFuncionarioString);

            while (!verificaFuncionario)
            {
                Console.WriteLine("Informe um funcionário válido!");
                Console.Write("ID do Funcionário: ");
                idDoFuncionarioString = Console.ReadLine();
                verificaFuncionario = _ordemServicoService.FuncionarioEhValido(idDoFuncionarioString);
            }

            string maisServicos = "";
            List<string> ServicosSelecionados = [];

            while (maisServicos.ToUpper() != "N")
            {
                Console.Write("ID do Serviço: ");
                string idDoServicoString = Console.ReadLine();
                bool verificaServico = _ordemServicoService.ServicoEhValido(idDoServicoString);

                while (!verificaServico)
                {
                    Console.WriteLine("Informe um Serviço válido!");
                    Console.Write("ID do Serviço: ");
                    idDoServicoString = Console.ReadLine();
                    verificaServico = _ordemServicoService.ServicoEhValido(idDoServicoString);
                }

                ServicosSelecionados.Add(idDoServicoString);

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
            List<string> PecasSelecionadas = [];

            while (maisPecas.ToUpper() != "N")
            {
                Console.Write("ID da Peça: ");
                string idDaPecaString = Console.ReadLine();
                bool verificaPeca = _ordemServicoService.PecaEhValida(idDaPecaString);

                while (!verificaPeca)
                {
                    Console.WriteLine("Informe uma Peça válida!");
                    Console.Write("ID da Peça: ");
                    idDaPecaString = Console.ReadLine();
                    verificaPeca = _ordemServicoService.PecaEhValida(idDaPecaString);
                }

                PecasSelecionadas.Add(idDaPecaString);

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
            bool verificaStatusOS = _ordemServicoService.StatusOSEhValido(statusOrdemServicoString);

            while (!verificaStatusOS)
            {
                Console.WriteLine("Informe um status válido.");
                Console.WriteLine("A - Aberta  |  P - Aguardando Peças  |  E - Em Andamento  |  F - Finalizada  |  C - Cancelada");
                Console.Write("Status da Ordem de Serviço: ");
                statusOrdemServicoString = Console.ReadLine();
                verificaStatusOS = _ordemServicoService.StatusOSEhValido(statusOrdemServicoString);
            }

            try
            {
                _ordemServicoService.CriarOrdemServico(idDoClienteString, 
                                                       placaDoVeiculo, 
                                                       idDoFuncionarioString, 
                                                       ServicosSelecionados, 
                                                       PecasSelecionadas, 
                                                       statusOrdemServicoString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Ordem de Serviço criada com sucesso.");
            Console.WriteLine();
        }

        public void AdicionarServicoNaOS()
        {
            Console.WriteLine("=== Adicionar um Serviço à O.S. ===");
            string desejaAddMaisServicos = "";
            int idServicoAdicionar;
            List<Servico> ServicosParaAdicionar = [];

            Console.Write("Número da Ordem de Serviço: ");
            string ordemDeServicoString = Console.ReadLine();
            bool ehOSValida = _ordemServicoService.OSEhCadastrada(ordemDeServicoString);

            while (!ehOSValida)
            {
                Console.WriteLine("Informe uma Ordem de Serviço válida!");
                Console.Write("Número da Ordem de Serviço: ");
                ordemDeServicoString = Console.ReadLine();
                ehOSValida = _ordemServicoService.OSEhCadastrada(ordemDeServicoString);
            }

            string maisServicos = "";
            List<string> ServicosSelecionados = [];

            while (maisServicos.ToUpper() != "N")
            {
                Console.Write("ID do Serviço: ");
                string idDoServicoString = Console.ReadLine();
                bool verificaServico = _ordemServicoService.ServicoEhValido(idDoServicoString);

                while (!verificaServico)
                {
                    Console.WriteLine("Informe um Serviço válido!");
                    Console.Write("ID do Serviço: ");
                    idDoServicoString = Console.ReadLine();
                    verificaServico = _ordemServicoService.ServicoEhValido(idDoServicoString);
                }

                ServicosSelecionados.Add(idDoServicoString);

                Console.Write("Há mais Serviços para adicionar? (S/N): ");
                maisServicos = Console.ReadLine();
                while (maisServicos.ToUpper() != "S" && maisServicos.ToUpper() != "N")
                {
                    Console.WriteLine("Opção inválida!");
                    Console.Write("Há mais Serviços para adicionar? (S/N): ");
                    maisServicos = Console.ReadLine();
                }
            }

            try
            {
                _ordemServicoService.AdicionarServicoNaOS(ordemDeServicoString, ServicosSelecionados);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
            bool ehOSValida = _ordemServicoService.OSEhCadastrada(ordemDeServicoString);

            while (!ehOSValida)
            {
                Console.WriteLine("Informe uma Ordem de Serviço válida!");
                Console.Write("Número da Ordem de Serviço: ");
                ordemDeServicoString = Console.ReadLine();
                ehOSValida = _ordemServicoService.OSEhCadastrada(ordemDeServicoString);
            }

            string maisPecas = "";
            List<string> PecasSelecionadas = [];

            while (maisPecas.ToUpper() != "N")
            {
                Console.Write("ID da Peça: ");
                string idDaPecaString = Console.ReadLine();
                bool verificaPeca = _ordemServicoService.PecaEhValida(idDaPecaString);

                while (!verificaPeca)
                {
                    Console.WriteLine("Informe uma Peça válida!");
                    Console.Write("ID da Peça: ");
                    idDaPecaString = Console.ReadLine();
                    verificaPeca = _ordemServicoService.PecaEhValida(idDaPecaString);
                }

                PecasSelecionadas.Add(idDaPecaString);

                Console.Write("Há mais Peças para adicionar? (S/N): ");
                maisPecas = Console.ReadLine();
                while (maisPecas.ToUpper() != "S" && maisPecas.ToUpper() != "N")
                {
                    Console.WriteLine("Opção inválida!");
                    Console.Write("Há mais Peças para adicionar? (S/N): ");
                    maisPecas = Console.ReadLine();
                }
            }

            try
            {
                _ordemServicoService.AdicionarPecasNaOS(ordemDeServicoString, PecasSelecionadas);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Peça(s) adicionada(s) com sucesso.");
            Console.WriteLine();
        }

        public void FinalizarOS()
        {
            Console.WriteLine("=== Fechar Ordem de Serviço ===");
            Console.Write("Número da Ordem de Serviço: ");
            string ordemDeServicoString = Console.ReadLine();
            bool ehOSValida = _ordemServicoService.OSEhCadastrada(ordemDeServicoString);

            while (!ehOSValida)
            {
                Console.WriteLine("Informe uma Ordem de Serviço válida!");
                Console.Write("Número da Ordem de Serviço: ");
                ordemDeServicoString = Console.ReadLine();
                ehOSValida = _ordemServicoService.OSEhCadastrada(ordemDeServicoString);
            }

            try
            {
                _ordemServicoService.FinalizarOS(ordemDeServicoString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Ordem de Serviço nº {ordemDeServicoString} foi finalizada com sucesso.");
            Console.WriteLine();
            
            // PENDENTE REIMPLEMENTAR
            // NotificacaoWPP notificacao = new NotificacaoWPP();
            // string mensagem = $"Olá, {OrdemDeServicoEmEdicao.Cliente.Nome}, tudo bem? Estamos passando para avisa-lo que os reparos no seu veículo {OrdemDeServicoEmEdicao.Veiculo.Marca} {OrdemDeServicoEmEdicao.Veiculo.Modelo} foram concluídos.";
            // notificacao.ConclusaoOrdemDeServicoAsync(mensagem);
        }

        public void CancelarOS()
        {
            Console.WriteLine("=== Cancelar Ordem de Serviço ===");
            Console.Write("Número da Ordem de Serviço: ");
            string ordemDeServicoString = Console.ReadLine();
            bool ehOSValida = _ordemServicoService.OSEhCadastrada(ordemDeServicoString);

            while (!ehOSValida)
            {
                Console.WriteLine("Informe uma Ordem de Serviço válida!");
                Console.Write("Número da Ordem de Serviço: ");
                ordemDeServicoString = Console.ReadLine();
                ehOSValida = _ordemServicoService.OSEhCadastrada(ordemDeServicoString);
            }

            try
            {
                _ordemServicoService.CancelarOS(ordemDeServicoString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Ordem de Serviço nº {ordemDeServicoString} foi cancelada.");
            Console.WriteLine();
        }

        public void ListarOrdensDeServico()
        {
            Console.WriteLine("=== Listar Ordens de Serviço ===");
            foreach (OrdemServico os in _ordemServicoService.ListarOrdensServicos())
            {
                Console.WriteLine(os.DetalharOrdemServico());
            }
            Console.WriteLine();
        }
    }
}