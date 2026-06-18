/* MVC
Models: Cliente, Funcionario, Veiculo, OrdemServico, Agendamento, Servico, Peca
Controllers: ClienteController, VeiculoController, OrdemServicoController, AgendamentoController
Views: ClienteView, VeiculoView, OrdemServicoView, AgendamentoView 
Services: ClienteService, AgendamentoService, OrdemServicoService, RelatorioService, NotificacaoService
Repositories: ClienteRepository, VeiculoRepository, OrdemServicoRepository, AgendamentoRepository

Ordem de Implementação: Models, Controllers, Views, Services e Repositories.
 */

/* 
Exercício Integrador: Sistema de Gestão de Oficina Mecânica
Objetivo: Desenvolver uma aplicação console em C# para gerenciamento de uma oficina mecânica.
A aplicação deverá controlar clientes, funcionários, veículos, serviços, ordens de serviço, estoque de peças e agendamentos.

O sistema deverá demonstrar obrigatoriamente o uso de:
- Estruturas de decisão e repetição
- Orientação a Objetos completa
- Coleções e LINQ
- Exceções personalizadas
- Operações assíncronas

Estrutura de Classes Obrigatória

Classe Abstrata Pessoa -  Representa qualquer pessoa cadastrada no sistema.
Atributos: Id, Nome, Telefone, Email
Métodos: ExibirDados()

Classe Cliente - Herda de Pessoa.
Atributos: DataCadastro, TotalGasto
Métodos: AtualizarTotalGasto()

Classe ClienteVip - Herda de Cliente.
Regras: Possui desconto especial em serviços.

Classe ClienteFrotista - Herda de Cliente.
Regras: Possui desconto diferente do ClienteVip.
Atributos: NomeEmpresa, QuantidadeVeiculos

Classe Funcionario - Herda de Pessoa.
Atributos: Cargo, Salario
Métodos: ExibirDados()

Hierarquia de Veículos
Classe Abstrata Veiculo
Atributos: Placa, Marca, Modelo, Ano
Métodos: CalcularTaxaServico()
- Classe Carro - Herda de Veiculo.
- Classe Moto - Herda de Veiculo.
- Classe Caminhao - Herda de Veiculo.
Cada tipo de veículo deve possuir comportamento próprio para cálculo da taxa de serviço.

Interface Obrigatória
INotificavel - A interface deverá ser implementada por uma classe responsável por notificações.
Métodos: EnviarNotificacaoAsync()
Exemplos: Email, WhatsApp e SMS. Escolha apenas uma implementação.

Classe Serviço - Representa um serviço executado pela oficina.
Atributos: Id, Nome, ValorBase, TempoEstimadoHoras
Exemplos de Serviços: Troca de óleo, Alinhamento, Balanceamento, Revisão, Diagnóstico eletrônico

Classe Peça - Representa um item do estoque.
Atributos: Id, Nome, Quantidade, PrecoUnitario
Métodos: BaixarEstoque(), ReporEstoque()

Classe OrdemServico - Representa o atendimento de um cliente.
Atributos: Numero, Cliente, Veiculo, FuncionarioResponsavel, ListaServicos, ListaPecas, DataAbertura e Status
Métodos: AdicionarServico(), AdicionarPeca(), CalcularValorTotal(), Finalizar(), Cancelar()

Enum Obrigatório - StatusOrdemServico
Criar os seguintes estados: Aberta, EmAndamento, AguardandoPecas, Finalizada, Cancelada

Classe Agendamento - Representa um horário reservado.
Atributos: Id, Cliente, Veiculo, DataHora, Servico
Métodos: Confirmar(), Cancelar()

Exceções Personalizadas Obrigatórias
HorarioIndisponivelException: Lançada quando existir conflito de horário.
EstoqueInsuficienteException: Lançada quando uma peça não possuir quantidade suficiente.
ServicoInvalidoException: Lançada quando o serviço não puder ser executado naquele veículo.
Exemplo: Serviço destinado apenas a caminhões sendo solicitado para motos.

Menu Principal - O sistema deverá permanecer em execução até o usuário escolher sair.

Opções
1. Clientes (1.1 Cadastrar cliente, 1.2 Listar clientes e 1.3 Buscar cliente)
2. Funcionários (2.1 Cadastrar funcionário e 2.2 Listar funcionários)
3. Veículos (3.1 Cadastrar veículo e 3.2 Listar veículos)
4. Estoque (4.1 Cadastrar peça, 4.2 Repor estoque e  4.3 Visualizar estoque)
5. Serviços (5.1 Cadastrar serviço e  5.2 Listar serviços)
6. Agendamentos (6.1 Criar agendamento, 6.2 Cancelar agendamento e 6.3 Listar agendamentos)
7. Ordens de Serviço (7.1 Abrir ordem, 7.2 Adicionar serviço, 7.3 Adicionar peça, 7.4 Finalizar ordem, 7.5 Cancelar ordem, 7.6 Listar ordens)
8. Relatórios (8.1 Faturamento total, 8.2 Serviços mais executados, 8.3 Clientes que mais gastaram, 8.4 Peças mais utilizadas e 8.5 Ordens em andamento)
9. Notificações (9.1 Enviar confirmação de agendamento, 9.2 Enviar conclusão de serviço)
0. Sair

Regras de Negócio Obrigatórias
- Cliente VIP - Recebe desconto próprio.
- Cliente Frotista - Recebe desconto diferente do VIP.
- Agendamento - Não pode existir dois agendamentos para o mesmo horário.
- Estoque - Não permitir saída de quantidade maior que disponível.
- Ordem de Serviço - Não pode ser finalizada sem possuir ao menos um serviço.
- Serviço - Deve validar compatibilidade com o tipo de veículo.

Consultas LINQ Obrigatórias
- Clientes VIP - Listar somente clientes VIP.
- Clientes por gasto - Ordenar clientes por TotalGasto.
- Faturamento - Somar valor de todas as ordens finalizadas.
- Serviços mais executados - Agrupar serviços por nome.
- Ordens em andamento - Filtrar apenas ordens com status EmAndamento.
- Peças com estoque baixo - Filtrar peças abaixo de uma quantidade mínima definida por você.

Operações Assíncronas Obrigatórias
As operações devem ser tratadas como tarefas demoradas, sem bloquear a execução principal da aplicação.
- Notificação de Agendamento
- Simular envio de confirmação
- Notificação de Conclusão
- Simular envio quando uma ordem for finalizada */

using Exercicio_Integrador_2.Controller;
using Exercicio_Integrador_2.Excecoes;
using Exercicio_Integrador_2.Interfaces;
using Exercicio_Integrador_2.Models;
using Exercicio_Integrador_2.Repository;
using Exercicio_Integrador_2.Service;

int opcaoMenu = -1;
StatusOrdemServico statusOrdemServico = new StatusOrdemServico();
ClienteRepository clienteRepository = new ClienteRepository();
ClienteService clienteService = new ClienteService(clienteRepository);
ClienteController clienteController = new ClienteController(clienteService);
FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
FuncionarioService funcionarioService = new FuncionarioService(funcionarioRepository);
FuncionarioController funcionarioController = new FuncionarioController(funcionarioService);
PecaRepository pecaRepository = new PecaRepository();
PecaService pecaService = new PecaService(pecaRepository);
PecaController pecaController = new PecaController(pecaService);
ServicoRepository servicoRepository = new ServicoRepository();
ServicoService servicoService = new ServicoService(servicoRepository);
ServicoController servicoController = new ServicoController(servicoService);
VeiculoRepository veiculoRepository = new VeiculoRepository();
VeiculoService veiculoService = new VeiculoService(veiculoRepository);
VeiculoController veiculoController = new VeiculoController(veiculoService);
AgendamentoRepository agendamentoRepository = new AgendamentoRepository(clienteRepository, veiculoRepository, servicoRepository, pecaRepository);
AgendamentoService agendamentoService = new AgendamentoService(agendamentoRepository, clienteRepository, veiculoRepository, servicoRepository, pecaRepository);
AgendamentoController agendamentoController = new AgendamentoController(agendamentoService);
OrdemServicoRepository ordemServicoRepository = new OrdemServicoRepository(clienteRepository, veiculoRepository, servicoRepository, pecaRepository, funcionarioRepository);
OrdemServicoService ordemServicoService = new OrdemServicoService(ordemServicoRepository, clienteRepository, veiculoRepository, funcionarioRepository, servicoRepository, pecaRepository);
OrdemServicoController ordemServicoController = new OrdemServicoController(ordemServicoService);
RelatorioService relatorioService = new RelatorioService(ordemServicoRepository, statusOrdemServico);

Console.WriteLine("=== Bem vindo ao Sistema de Gestão para Oficinas ===");

while (opcaoMenu != 0)
{
    Console.WriteLine();
    Console.WriteLine("=== Menu Principal ===");
    Console.WriteLine("1. Clientes");
    Console.WriteLine("2. Funcionários");
    Console.WriteLine("3. Veículos");
    Console.WriteLine("4. Estoque");
    Console.WriteLine("5. Serviços");
    Console.WriteLine("6. Agendamentos");
    Console.WriteLine("7. Ordens de Serviço");
    Console.WriteLine("8. Relatórios"); // PENDENTE MÓDULO 8
    Console.WriteLine("9. Notificações"); // PENDENTE MÓDULO 9
    Console.WriteLine("0. Sair");
    Console.Write("Selecione uma das opções: ");
    string inputUsuario = Console.ReadLine();
    bool opcaoMenuEhValida = int.TryParse(inputUsuario, out opcaoMenu);

    while (!opcaoMenuEhValida)
    {
        Console.WriteLine("Opção selecionada inválida.");
        Console.Write("Selecione uma das opções: ");
        inputUsuario = Console.ReadLine();
        opcaoMenuEhValida = int.TryParse(inputUsuario, out opcaoMenu);
    }

    Console.WriteLine();

    switch (opcaoMenu)
    {
        // Menu Clientes
        case 1:
            while (opcaoMenu != 0)
            {
                Console.WriteLine("=== Menu de Clientes === ");
                Console.WriteLine("1. Cadastrar Cliente");
                Console.WriteLine("2. Listar Clientes");
                Console.WriteLine("3. Buscar Cliente");
                Console.WriteLine("0. Retornar ao menu anterior");
                Console.Write("Selecione uma das opções: ");
                inputUsuario = Console.ReadLine();
                opcaoMenuEhValida = int.TryParse(inputUsuario, out opcaoMenu);

                while (!opcaoMenuEhValida)
                {
                    Console.WriteLine("Opção selecionada inválida.");
                    Console.Write("Selecione uma das opções: ");
                    inputUsuario = Console.ReadLine();
                    opcaoMenuEhValida = int.TryParse(inputUsuario, out opcaoMenu);
                }

                
                switch (opcaoMenu)
                {
                    // Cadastrar Cliente
                    case 1:
                        Console.WriteLine();    
                        clienteController.CadastrarCliente();
                        break;

                    // Listar Clientes
                    case 2:
                        Console.WriteLine();
                        clienteController.ListarClientes();
                        break;

                    // Buscar Cliente
                    case 3:
                        Console.WriteLine();
                        clienteController.BuscarCliente();
                        break;
                    default:
                        break;
                }
            }
            opcaoMenu = -1;
            break;

        // Menu Funcionários
        case 2:
            while (opcaoMenu != 0)
            {
                Console.WriteLine("=== Menu de Funcionários === ");
                Console.WriteLine("1. Cadastrar funcionário");
                Console.WriteLine("2. Listar funcionários");
                Console.WriteLine("0. Retornar ao menu anterior");
                Console.Write("Selecione uma das opções: ");
                inputUsuario = Console.ReadLine();
                opcaoMenuEhValida = int.TryParse(inputUsuario, out opcaoMenu);

                while (!opcaoMenuEhValida)
                {
                    Console.WriteLine("Opção selecionada inválida.");
                    Console.Write("Selecione uma das opções: ");
                    inputUsuario = Console.ReadLine();
                    opcaoMenuEhValida = int.TryParse(inputUsuario, out opcaoMenu);
                }

                switch (opcaoMenu)
                {
                    // Cadastrar funcionário
                    case 1:
                        Console.WriteLine();
                        funcionarioController.CadastrarFuncionario();
                        break;

                    // Listar funcionários
                    case 2:
                        Console.WriteLine();
                        funcionarioController.ListarFuncionarios();
                        break;

                    default:
                        break;
                }
            }
            opcaoMenu = -1;
            break;

        // Menu Veículos
        case 3:
            while (opcaoMenu != 0)
            {
                Console.WriteLine("=== Menu de Veículos === ");
                Console.WriteLine("1. Cadastrar veículo");
                Console.WriteLine("2. Listar veículos");
                Console.WriteLine("0. Retornar ao menu anterior");
                Console.Write("Selecione uma das opções: ");
                inputUsuario = Console.ReadLine();
                opcaoMenuEhValida = int.TryParse(inputUsuario, out opcaoMenu);

                while (!opcaoMenuEhValida)
                {
                    Console.WriteLine("Opção selecionada inválida.");
                    Console.Write("Selecione uma das opções: ");
                    inputUsuario = Console.ReadLine();
                    opcaoMenuEhValida = int.TryParse(inputUsuario, out opcaoMenu);
                }

                switch (opcaoMenu)
                {
                    // Cadastrar veículo
                    case 1:
                        Console.WriteLine();
                        veiculoController.CadastrarVeiculo();
                        break;

                    // Listar veículos
                    case 2:
                        Console.WriteLine();
                        veiculoController.ListarVeiculos();
                        break;

                    default:
                        break;
                }
            }
            opcaoMenu = -1;
            break;

        // Menu Estoque
        case 4:
            while (opcaoMenu != 0)
            {
                Console.WriteLine("=== Menu de Estoque === ");
                Console.WriteLine("1. Cadastrar peça");
                Console.WriteLine("2. Repor estoque");
                Console.WriteLine("3. Visualizar estoque");
                Console.WriteLine("0. Retornar ao menu anterior");
                Console.Write("Selecione uma das opções: ");
                inputUsuario = Console.ReadLine();
                opcaoMenuEhValida = int.TryParse(inputUsuario, out opcaoMenu);

                while (!opcaoMenuEhValida)
                {
                    Console.WriteLine("Opção selecionada inválida.");
                    Console.Write("Selecione uma das opções: ");
                    inputUsuario = Console.ReadLine();
                    opcaoMenuEhValida = int.TryParse(inputUsuario, out opcaoMenu);
                }

                switch (opcaoMenu)
                {
                    // Cadastrar peça
                    case 1:
                        Console.WriteLine();
                        pecaController.CadastrarPeca();
                        break;

                    // Repor estoque
                    case 2:
                        Console.WriteLine();
                        pecaController.ReporEstoque();
                        break;

                    // Visualizar estoque
                    case 3:
                        Console.WriteLine();
                        pecaController.ListarPecas();
                        break;

                    default:
                        break;
                }
            }
            opcaoMenu = -1;
            break;

        // Menu Serviços
        case 5:
            while (opcaoMenu != 0)
            {
                Console.WriteLine("=== Menu de Serviços === ");
                Console.WriteLine("1. Cadastrar serviço");
                Console.WriteLine("2. Listar serviços");
                Console.WriteLine("0. Retornar ao menu anterior");
                Console.Write("Selecione uma das opções: ");
                inputUsuario = Console.ReadLine();
                opcaoMenuEhValida = int.TryParse(inputUsuario, out opcaoMenu);

                while (!opcaoMenuEhValida)
                {
                    Console.WriteLine("Opção selecionada inválida.");
                    Console.Write("Selecione uma das opções: ");
                    inputUsuario = Console.ReadLine();
                    opcaoMenuEhValida = int.TryParse(inputUsuario, out opcaoMenu);
                }

                switch (opcaoMenu)
                {
                    // Cadastrar serviço
                    case 1:
                        Console.WriteLine();
                        servicoController.CadastrarServico();
                        break;

                    // Listar serviços
                    case 2:
                        Console.WriteLine();
                        servicoController.ListarServicos();
                        break;

                    default:
                        break;
                }
            }
            opcaoMenu = -1;
            break;

        // Menu Agendamentos
        case 6:
            while (opcaoMenu != 0)
            {
                Console.WriteLine("=== Menu de Agendamentos === ");
                Console.WriteLine("1. Criar agendamento");
                Console.WriteLine("2. Cancelar agendamento");
                Console.WriteLine("3. Listar agendamentos");
                Console.WriteLine("0. Retornar ao menu anterior");
                Console.Write("Selecione uma das opções: ");
                inputUsuario = Console.ReadLine();
                opcaoMenuEhValida = int.TryParse(inputUsuario, out opcaoMenu);

                while (!opcaoMenuEhValida)
                {
                    Console.WriteLine("Opção selecionada inválida.");
                    Console.Write("Selecione uma das opções: ");
                    inputUsuario = Console.ReadLine();
                    opcaoMenuEhValida = int.TryParse(inputUsuario, out opcaoMenu);
                }

                switch (opcaoMenu)
                {
                    // Criar agendamento
                    case 1:
                        Console.WriteLine();
                        agendamentoController.CadastrarAgendamento();
                        break;

                    // Cancelar agendamento
                    case 2:
                        Console.WriteLine();
                        agendamentoController.CancelarAgendamento();
                        break;

                    // Listar agendamentos
                    case 3:
                        Console.WriteLine();
                        agendamentoController.ListarAgendamentos();
                        break;

                    default:
                        break;
                }
            }
            opcaoMenu = -1;
            break;

        // Menu Ordem de Serviço
        case 7:
            while (opcaoMenu != 0)
            {
                Console.WriteLine("=== Menu de Ordem de Serviço === ");
                Console.WriteLine("1. Abrir ordem");
                Console.WriteLine("2. Adicionar serviço");
                Console.WriteLine("3. Adicionar peça");
                Console.WriteLine("4. Finalizar ordem");
                Console.WriteLine("5. Cancelar ordem");
                Console.WriteLine("6. Listar ordens");
                Console.WriteLine("0. Retornar ao menu anterior");
                Console.Write("Selecione uma das opções: ");
                inputUsuario = Console.ReadLine();
                opcaoMenuEhValida = int.TryParse(inputUsuario, out opcaoMenu);

                while (!opcaoMenuEhValida)
                {
                    Console.WriteLine("Opção selecionada inválida.");
                    Console.Write("Selecione uma das opções: ");
                    inputUsuario = Console.ReadLine();
                    opcaoMenuEhValida = int.TryParse(inputUsuario, out opcaoMenu);
                }

                switch (opcaoMenu)
                {
                    // Abrir ordem
                    case 1:
                        Console.WriteLine();
                        ordemServicoController.CriarOS();
                        break;

                    // Adicionar serviço
                    case 2:
                        Console.WriteLine();
                        ordemServicoController.AdicionarServicoNaOS();
                        break;

                    // Adicionar peça
                    case 3:
                        Console.WriteLine();
                        ordemServicoController.AdicionarPecaNaOS();
                        break;

                    // Finalizar ordem
                    case 4:
                        Console.WriteLine();
                        ordemServicoController.FinalizarOS();
                        break;

                    // Cancelar ordem
                    case 5:
                        Console.WriteLine();
                        ordemServicoController.CancelarOS();
                        break;

                    // Listar ordens
                    case 6:
                        Console.WriteLine();
                        ordemServicoController.ListarOrdensDeServico();
                        break;

                    default:
                        break;
                }
            }
            opcaoMenu = -1;
            break;

        // Menu Relatórios
        case 8:
            while (opcaoMenu != 0)
            {
                Console.WriteLine("=== Menu de Relatório === ");
                Console.WriteLine("1. Faturamento total");
                Console.WriteLine("2. Serviços mais executados");
                Console.WriteLine("3. Clientes que mais gastaram");
                Console.WriteLine("4. Peças mais utilizadas");
                Console.WriteLine("5. Ordens em andamento");
                Console.WriteLine("0. Retornar ao menu anterior");
                Console.Write("Selecione uma das opções: ");
                inputUsuario = Console.ReadLine();
                opcaoMenuEhValida = int.TryParse(inputUsuario, out opcaoMenu);

                while (!opcaoMenuEhValida)
                {
                    Console.WriteLine("Opção selecionada inválida.");
                    Console.Write("Selecione uma das opções: ");
                    inputUsuario = Console.ReadLine();
                    opcaoMenuEhValida = int.TryParse(inputUsuario, out opcaoMenu);
                }

                switch (opcaoMenu)
                {
                    // Faturamento total
                    case 1:
                        relatorioService.FaturamentoTotal();
                        break;

                    // Serviços mais executados
                    case 2:
                        relatorioService.ServicosMaisExecutados();
                        break;

                    // Clientes que mais gastaram
                    case 3:
                        relatorioService.ClientesMaiorFaturamento();
                        break;

                    // Peças mais utilizadas
                    case 4:
                        relatorioService.PecasMaisVendidas();
                        break;

                    // Ordens em andamento
                    case 5:
                        relatorioService.OrdensServicoEmAndamento();
                        break;

                    default:
                        break;
                }
            }
            opcaoMenu = -1;
            break;

        // Menu Notificações
        case 9:
            while (opcaoMenu != 0)
            {
                Console.WriteLine("=== Menu de Notificação === ");
                Console.WriteLine("1. Enviar confirmação de agendamento");
                Console.WriteLine("2. Enviar conclusão de serviço");
                Console.WriteLine("0. Retornar ao menu anterior");
                Console.Write("Selecione uma das opções: ");
                inputUsuario = Console.ReadLine();
                opcaoMenuEhValida = int.TryParse(inputUsuario, out opcaoMenu);
                NotificacaoWPP notificacao = new NotificacaoWPP();

                while (!opcaoMenuEhValida)
                {
                    Console.WriteLine("Opção selecionada inválida.");
                    Console.Write("Selecione uma das opções: ");
                    inputUsuario = Console.ReadLine();
                    opcaoMenuEhValida = int.TryParse(inputUsuario, out opcaoMenu);
                }

                switch (opcaoMenu)
                {
                    // Enviar confirmação de agendamento
                    case 1:
                        //Console.WriteLine();
                        //Console.WriteLine("=== Notificação | Confirmar Agendamento ===");
                        //List<Agendamento> agendamentosParaConfirmar = Agendamentos.Where(a => a.Status == StatusOrdemServico.Agendada).ToList();

                        //foreach (Agendamento agendamento in agendamentosParaConfirmar)
                        //{
                        //    string mensagem = $"Olá, {agendamento.Cliente.Nome}, tudo bem? Seu veículo {agendamento.Veiculo.Marca} {agendamento.Veiculo.Modelo} tem um horário agendado para {agendamento.DataAgendamento}. Por gentileza poderia confirmar?";
                        //    notificacao.ConfirmarAgendamentosAsync(mensagem);
                        //}
                        //Console.WriteLine();
                        break;

                    // Enviar conclusão de serviço
                    case 2:
                        //Console.WriteLine();
                        //Console.WriteLine("=== Notificação | Conclusão da O.S. ===");
                        //List<OrdemServico> ordensDeServicoFinalizadas = OrdensDeServico.Where(a => a.Status == StatusOrdemServico.Finalizada).ToList();

                        //foreach (OrdemServico ordemServico in ordensDeServicoFinalizadas)
                        //{
                        //    string mensagem = $"Olá, {ordemServico.Cliente.Nome}, tudo bem? Estamos passando para avisa-lo que os reparos no seu veículo {ordemServico.Veiculo.Marca} {ordemServico.Veiculo.Modelo} foram concluídos.";
                        //    notificacao.ConclusaoOrdemDeServicoAsync(mensagem);
                        //}
                        //Console.WriteLine();
                        break;

                    default:
                        break;
                }
            }
            opcaoMenu = -1;
            break;
        default:
            break;
    }
}