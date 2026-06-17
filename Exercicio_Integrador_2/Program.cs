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
- Simular envio quando uma ordem for finalizada
*/

using Exercicio_Integrador_2.Excecoes;
using Exercicio_Integrador_2.Interfaces;
using Exercicio_Integrador_2.Modulos;
using Exercicio_Integrador_2.Pessoas;
using Exercicio_Integrador_2.Veiculos;

List<Cliente> Clientes = new List<Cliente>
{
    new Cliente(1, "Gabriel", "47 98888-9999", "gabriel@email.com", DateTime.UtcNow, 0),
    new Cliente(2, "Marcia", "47 98888-9999", "marcia@email.com", DateTime.UtcNow, 0),
    new ClienteFrotista(3, "Paulo", "47 98888-9999", "paulo@email.com", DateTime.UtcNow, 10000, "Paulo Veículos ME", 4),
    new ClienteFrotista(4, "Carlos", "47 98888-9999", "carlos@email.com", DateTime.UtcNow, 50000, "Carlos Veículos ME", 11),
    new ClienteVip(5, "Pedro", "47 98888-9999", "pedro@email.com", DateTime.UtcNow, 1000),
    new ClienteVip(6, "Cássia", "47 98888-9999", "cassia@email.com", DateTime.UtcNow, 1000)
};

List<Funcionario> Funcionarios = new List<Funcionario>
{
    new Funcionario(7, "Marlon", "47 98888-9999", "marlon@email.com", "Gerente", 15000),
    new Funcionario(8, "Kassio", "47 98888-9999", "kassio@email.com", "Mecânico Sênior", 6500),
    new Funcionario(9, "Alan", "47 98888-9999", "alan@email.com", "Mecânico Júnior", 3000)
};

List<Veiculo> Veiculos = new List<Veiculo>
{
    new Caminhao("AAA-0A00", "VOLVO", "FH 540", 1990),
    new Caminhao("AAA-0A01", "VOLVO", "FH 460", 1991),
    new Caminhao("AAA-0A02", "SCANIA", "R450", 1992),
    new Caminhao("AAA-0A03", "SCANIA", "R500", 2000),
    new Caminhao("AAA-0A04", "VOLKSWAGEN", "DELIVERY 11180", 2005),
    new Carro("AAA-0A05", "VOLKSWAGEN", "GOL", 2009),
    new Carro("AAA-0A06", "VOLKSWAGEN", "POLO", 2015),
    new Carro("AAA-0A07", "FIAT", "ARGO", 2026),
    new Carro("AAA-0A08", "FIAT", "STRADA", 2000),
    new Carro("AAA-0A09", "CHEVROLET", "ONIX", 2019),
    new Carro("AAA-0A10", "CHEVROLET", "ONIX", 2020),
    new Carro("AAA-0A11", "TOYOTA", "COROLLA", 2021),
    new Carro("AAA-0A12", "BYD", "DOLPHIN", 2025),
    new Moto("AAA-0A13", "HONDA", "CG 160", 2019),
    new Moto("AAA-0A14", "YAMAHA", "FACTOR 150", 2023),
    new Moto("AAA-0A15", "YAMAHA", "FAZER", 2026),
    new Moto("AAA-0A16", "HONDA", "BIZ", 2026),
    new Moto("AAA-0A17", "HONDA", "BIZ", 2025),
    new Moto("AAA-0A18", "YAMAHA", "LANDER", 2025)
};

List<Peca> Pecas = new List<Peca>
{
    new Peca(1, "Bieleta", 0, 100.50m),
    new Peca(2, "Filtro de Óleo", 10, 25.90m),
    new Peca(3, "Filtro de Ar", 8, 35.50m),
    new Peca(4, "Pastilha de Freio", 12, 89.90m),
    new Peca(5, "Disco de Freio", 6, 180.00m),
    new Peca(6, "Amortecedor Dianteiro", 4, 320.00m),
    new Peca(7, "Amortecedor Traseiro", 4, 295.00m),
    new Peca(8, "Correia Dentada", 5, 145.00m),
    new Peca(9, "Bateria 60Ah", 3, 450.00m),
    new Peca(10, "Velas de Ignição", 20, 18.50m),
    new Peca(11, "Bobina de Ignição", 7, 220.00m),
    new Peca(12, "Radiador", 2, 580.00m),
    new Peca(13, "Bomba de Combustível", 5, 310.00m),
    new Peca(14, "Rolamento de Roda", 9, 75.00m),
    new Peca(15, "Terminal de Direção", 11, 68.90m)
};

List<Servico> Servicos = new List<Servico>
{
    new Servico(1, "Alinhamento", 100.00m, 2),
    new Servico(2, "Balanceamento", 80.00m, 1),
    new Servico(3, "Troca de Óleo", 120.00m, 1),
    new Servico(4, "Revisão Completa", 450.00m, 6),
    new Servico(5, "Diagnóstico Eletrônico", 150.00m, 2),
    new Servico(6, "Troca de Pastilhas de Freio", 180.00m, 3),
    new Servico(7, "Substituição de Amortecedores", 350.00m, 4)
};

List<OrdemServico> OrdensDeServico = new List<OrdemServico>
{
    new OrdemServico(
        1,
        Clientes.FirstOrDefault(p => p.Id == 1),
        Veiculos.FirstOrDefault(v => v.Placa == "AAA-0A00"),
        Funcionarios.FirstOrDefault(p => p.Id == 9),
        Servicos.Where(s => s.Id >= 1 && s.Id <= 3).ToList(),
        Pecas.Where(pe => pe.Id == 2).ToList(),
        DateTime.UtcNow,
        StatusOrdemServico.Aberta
    ),

    new OrdemServico(
        2,
        Clientes.FirstOrDefault(p => p.Id == 2),
        Veiculos.FirstOrDefault(v => v.Placa == "AAA-0A01"),
        Funcionarios.FirstOrDefault(p => p.Id == 8),
        Servicos.Where(s => s.Id > 0).ToList(),
        Pecas.Where(pe => pe.Id > 0).ToList(),
        DateTime.UtcNow,
        StatusOrdemServico.Aberta
    ),

    new OrdemServico(
        3,
        Clientes.FirstOrDefault(p => p.Id == 5),
        Veiculos.FirstOrDefault(v => v.Placa == "AAA-0A11"),
        Funcionarios.FirstOrDefault(p => p.Id == 8),
        Servicos.Where(s => s.Id >= 4 && s.Id <= 5).ToList(),
        Pecas.Where(pe => pe.Id >= 9 && pe.Id <= 11).ToList(),
        DateTime.UtcNow,
        StatusOrdemServico.EmAndamento
    ),

    new OrdemServico(
        4,
        Clientes.FirstOrDefault(p => p.Id == 3),
        Veiculos.FirstOrDefault(v => v.Placa == "AAA-0A02"),
        Funcionarios.Where(p => p.Id == 7).FirstOrDefault(),
        Servicos.Where(s => s.Id >= 1 && s.Id <= 4).ToList(),
        Pecas.Where(pe => pe.Id >= 1 && pe.Id <= 5).ToList(),
        DateTime.UtcNow,
        StatusOrdemServico.AguardaPecas
    ),

    new OrdemServico(
        5,
        Clientes.FirstOrDefault(p => p.Id == 6),
        Veiculos.FirstOrDefault(v => v.Placa == "AAA-0A15"),
        Funcionarios.FirstOrDefault(p => p.Id == 9),
        Servicos.Where(s => s.Id == 3 || s.Id == 5).ToList(),
        Pecas.Where(pe => pe.Id == 2 || pe.Id == 10).ToList(),
        DateTime.UtcNow,
        StatusOrdemServico.Finalizada
    )
};

List<Agendamento> Agendamentos = new List<Agendamento>
{
    new Agendamento(
        1,
        Clientes.First(p => p.Id == 6),
        Veiculos.FirstOrDefault(v => v.Placa == "AAA-0A15"),
        Servicos.Where(s => s.Id == 3 || s.Id == 5).ToList(),
        Pecas.Where(pe => pe.Id == 2 || pe.Id == 10).ToList(),
        DateTime.UtcNow.AddDays(5),
        StatusOrdemServico.Agendada
    ),

    new Agendamento(
        2,
        Clientes.First(c => c.Id == 1),
        Veiculos.First(v => v.Placa == "AAA-0A05"),
        Servicos.Where(s => s.Id == 1 || s.Id == 2).ToList(),
        Pecas.Where(p => p.Id == 14).ToList(),
        DateTime.UtcNow.AddHours(6),
        StatusOrdemServico.Agendada
    ),

    new Agendamento(
        3,
        Clientes.First(c => c.Id == 3),
        Veiculos.First(v => v.Placa == "AAA-0A02"),
        Servicos.Where(s => s.Id == 4 || s.Id == 5).ToList(),
        Pecas.Where(p => p.Id >= 1 && p.Id <= 5).ToList(),
        DateTime.UtcNow.AddDays(1),
        StatusOrdemServico.Agendada
    ),

    new Agendamento(
        4,
        Clientes.First(c => c.Id == 5),
        Veiculos.First(v => v.Placa == "AAA-0A11"),
        Servicos.Where(s => s.Id == 7).ToList(),
        Pecas.Where(p => p.Id == 6 || p.Id == 7).ToList(),
        DateTime.UtcNow.AddHours(15),
        StatusOrdemServico.Agendada
    ),

    new Agendamento(
        5,
        Clientes.First(c => c.Id == 2),
        Veiculos.First(v => v.Placa == "AAA-0A09"),
        Servicos.Where(s => s.Id == 3).ToList(),
        Pecas.Where(p => p.Id == 2).ToList(),
        DateTime.UtcNow.AddDays(3),
        StatusOrdemServico.Agendada
    ),

    new Agendamento(
        6,
        Clientes.First(c => c.Id == 4),
        Veiculos.First(v => v.Placa == "AAA-0A04"),
        Servicos.Where(s => s.Id >= 1 && s.Id <= 4).ToList(),
        Pecas.Where(p => p.Id >= 8 && p.Id <= 12).ToList(),
        DateTime.UtcNow.AddDays(10),
        StatusOrdemServico.Agendada
    ),

    new Agendamento(
        7,
        Clientes.First(p => p.Id == 6),
        Veiculos.FirstOrDefault(v => v.Placa == "AAA-0A15"),
        Servicos.Where(s => s.Id == 3 || s.Id == 5).ToList(),
        Pecas.Where(pe => pe.Id == 2 || pe.Id == 10).ToList(),
        DateTime.UtcNow.AddHours(20),
        StatusOrdemServico.Agendada
    ),

    new Agendamento(
        8,
        Clientes.First(c => c.Id == 1),
        Veiculos.First(v => v.Placa == "AAA-0A05"),
        Servicos.Where(s => s.Id == 1 || s.Id == 2).ToList(),
        Pecas.Where(p => p.Id == 14).ToList(),
        DateTime.UtcNow.AddHours(2),
        StatusOrdemServico.Agendada
    ),

    new Agendamento(
        9,
        Clientes.First(c => c.Id == 3),
        Veiculos.First(v => v.Placa == "AAA-0A02"),
        Servicos.Where(s => s.Id == 4 || s.Id == 5).ToList(),
        Pecas.Where(p => p.Id >= 1 && p.Id <= 5).ToList(),
        DateTime.UtcNow.AddDays(4),
        StatusOrdemServico.Agendada
    ),

    new Agendamento(
        10,
        Clientes.First(c => c.Id == 5),
        Veiculos.First(v => v.Placa == "AAA-0A11"),
        Servicos.Where(s => s.Id == 7).ToList(),
        Pecas.Where(p => p.Id == 6 || p.Id == 7).ToList(),
        DateTime.UtcNow.AddHours(6),
        StatusOrdemServico.Agendada
    ),

    new Agendamento(
        11,
        Clientes.First(c => c.Id == 2),
        Veiculos.First(v => v.Placa == "AAA-0A09"),
        Servicos.Where(s => s.Id == 3).ToList(),
        Pecas.Where(p => p.Id == 2).ToList(),
        DateTime.UtcNow.AddDays(6),
        StatusOrdemServico.Agendada
    ),

    new Agendamento(
        12,
        Clientes.First(c => c.Id == 4),
        Veiculos.First(v => v.Placa == "AAA-0A04"),
        Servicos.Where(s => s.Id >= 1 && s.Id <= 4).ToList(),
        Pecas.Where(p => p.Id >= 8 && p.Id <= 12).ToList(),
        DateTime.UtcNow.AddDays(9),
        StatusOrdemServico.Agendada
    ),

    new Agendamento(
        13,
        Clientes.First(p => p.Id == 6),
        Veiculos.FirstOrDefault(v => v.Placa == "AAA-0A15"),
        Servicos.Where(s => s.Id == 3 || s.Id == 5).ToList(),
        Pecas.Where(pe => pe.Id == 2 || pe.Id == 10).ToList(),
        DateTime.UtcNow.AddHours(1),
        StatusOrdemServico.Agendada
    ),

    new Agendamento(
        14,
        Clientes.First(c => c.Id == 1),
        Veiculos.First(v => v.Placa == "AAA-0A05"),
        Servicos.Where(s => s.Id == 1 || s.Id == 2).ToList(),
        Pecas.Where(p => p.Id == 14).ToList(),
        DateTime.UtcNow.AddHours(4),
        StatusOrdemServico.Agendada
    ),

    new Agendamento(
        15,
        Clientes.First(c => c.Id == 3),
        Veiculos.First(v => v.Placa == "AAA-0A02"),
        Servicos.Where(s => s.Id == 4 || s.Id == 5).ToList(),
        Pecas.Where(p => p.Id >= 1 && p.Id <= 5).ToList(),
        DateTime.UtcNow.AddDays(2),
        StatusOrdemServico.Agendada
    ),

    new Agendamento(
        16,
        Clientes.First(c => c.Id == 5),
        Veiculos.First(v => v.Placa == "AAA-0A11"),
        Servicos.Where(s => s.Id == 7).ToList(),
        Pecas.Where(p => p.Id == 6 || p.Id == 7).ToList(),
        DateTime.UtcNow.AddHours(15),
        StatusOrdemServico.Agendada
    ),

    new Agendamento(
        17,
        Clientes.First(c => c.Id == 2),
        Veiculos.First(v => v.Placa == "AAA-0A09"),
        Servicos.Where(s => s.Id == 3).ToList(),
        Pecas.Where(p => p.Id == 2).ToList(),
        DateTime.UtcNow.AddDays(7),
        StatusOrdemServico.Agendada
    ),

    new Agendamento(
        18,
        Clientes.First(c => c.Id == 4),
        Veiculos.First(v => v.Placa == "AAA-0A04"),
        Servicos.Where(s => s.Id >= 1 && s.Id <= 4).ToList(),
        Pecas.Where(p => p.Id >= 8 && p.Id <= 12).ToList(),
        DateTime.UtcNow.AddDays(4),
        StatusOrdemServico.Agendada
    )
};

int opcaoMenu = -1;
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
    Console.WriteLine("8. Relatórios");
    Console.WriteLine("9. Notificações");
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
                        Console.WriteLine("=== Cadastrar Cliente ===");
                        Console.Write("Nome do Cliente: ");
                        string nomeCliente = Console.ReadLine();

                        Console.Write("Telefone: ");
                        string telefoneCliente = Console.ReadLine();

                        Console.Write("E-mail: ");
                        string emailCliente = Console.ReadLine();

                        string tipoCliente;
                        do
                        {
                            Console.Write("Tipo do Cliente | C - Padrão | V - VIP | F - FROTAS: ");
                            tipoCliente = Console.ReadLine();
                        } while (tipoCliente.ToUpper() != "C" && tipoCliente.ToUpper() != "V" && tipoCliente.ToUpper() != "F");

                        string nomeEmpresa = "";
                        int qtdVeiculos = 0;
                        string qtdVeiculosString;
                        if (tipoCliente.ToUpper() == "F")
                        {
                            Console.Write("Nome da Empresa: ");
                            nomeEmpresa = Console.ReadLine();
                            Console.Write("Quantidade de Veículos: ");
                            qtdVeiculosString = Console.ReadLine();
                            bool ehNumeroValido = int.TryParse(qtdVeiculosString, out qtdVeiculos);

                            while (!ehNumeroValido || qtdVeiculos <= 0)
                            {
                                Console.WriteLine("Digite um número válido!");
                                Console.Write("Quantidade de Veículos: ");
                                qtdVeiculosString = Console.ReadLine();
                                ehNumeroValido = int.TryParse(qtdVeiculosString, out qtdVeiculos);
                            }
                        }

                        if (tipoCliente == "C")
                        {
                            Cliente novoCliente = new Cliente(Clientes.Count + 1, nomeCliente, telefoneCliente, emailCliente, DateTime.UtcNow, 0);
                            Clientes.Add(novoCliente);
                        }
                        else if (tipoCliente == "V")
                        {
                            Cliente novoCliente = new ClienteVip(Clientes.Count + 1, nomeCliente, telefoneCliente, emailCliente, DateTime.UtcNow, 0);
                            Clientes.Add(novoCliente);
                        }
                        else
                        {
                            Cliente novoCliente = new ClienteFrotista(Clientes.Count + 1, nomeCliente, telefoneCliente, emailCliente, DateTime.UtcNow, 0, nomeEmpresa, qtdVeiculos);
                            Clientes.Add(novoCliente);
                        }

                        Console.WriteLine("Cliente cadastrado com sucesso.");
                        Console.WriteLine();
                        nomeCliente = "";
                        telefoneCliente = "";
                        emailCliente = "";
                        nomeEmpresa = "";
                        qtdVeiculos = 0;
                        break;

                    // Listar Clientes
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("=== Clientes Cadastrados ===");
                        foreach (Cliente cliente in Clientes)
                        {
                            Console.WriteLine(cliente.ExibirDados());
                        }
                        Console.WriteLine();
                        break;

                    // Buscar Cliente
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("=== Buscar Cliente ===");
                        Console.Write("Informe o Nome para pesquisar: ");
                        string nomePesquisaCliente = Console.ReadLine();
                        if (Clientes.Any(c => c.Nome.ToUpper() == nomePesquisaCliente.ToUpper()))
                        {
                            Console.WriteLine("Pessoa cadastrada na base de Clientes.");
                        }
                        else
                        {
                            Console.WriteLine("Pessoa não cadastrada na base de Clientes.");
                        }
                        Console.WriteLine();
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
                        Console.WriteLine("=== Cadastrar Funcionário ===");
                        Console.Write("Nome do Funcionário: ");
                        string nomeFuncionario = Console.ReadLine();

                        Console.Write("Telefone: ");
                        string telefoneFuncionario = Console.ReadLine();

                        Console.Write("E-mail: ");
                        string emailFuncionario = Console.ReadLine();

                        Console.Write("Cargo: ");
                        string cargoFuncionario = Console.ReadLine();

                        Console.Write("Salário R$: ");
                        string salarioFuncionarioString = Console.ReadLine();
                        decimal salarioFuncionario;
                        bool ehSalarioValido = decimal.TryParse(salarioFuncionarioString, out salarioFuncionario);

                        while (!ehSalarioValido || salarioFuncionario <= 0)
                        {
                            Console.WriteLine("Digite um número válido!");
                            Console.Write("Salário R$: ");
                            salarioFuncionarioString = Console.ReadLine();
                            ehSalarioValido = decimal.TryParse(salarioFuncionarioString, out salarioFuncionario);
                        }

                        Funcionario novoFuncionario = new Funcionario(Funcionarios.Count + 1, nomeFuncionario, telefoneFuncionario, emailFuncionario, cargoFuncionario, salarioFuncionario);
                        Funcionarios.Add(novoFuncionario);
                        Console.WriteLine("Funcionário cadastrado com sucesso.");
                        Console.WriteLine();
                        nomeFuncionario = "";
                        telefoneFuncionario = "";
                        emailFuncionario = "";
                        cargoFuncionario = "";
                        salarioFuncionario = 0;
                        break;

                    // Listar funcionários
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("=== Listar Funcionários ===");

                        foreach (Funcionario funcionario in Funcionarios)
                        {
                            Console.WriteLine(funcionario.ExibirDados());
                        }
                        Console.WriteLine();
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
                        Console.WriteLine("=== Cadastrar Veículo ===");
                        Console.Write("Placa: ");
                        string placaVeiculo = Console.ReadLine();

                        Console.Write("Marca: ");
                        string marcaVeiculo = Console.ReadLine();

                        Console.Write("Modelo: ");
                        string modeloVeiculo = Console.ReadLine();

                        Console.Write("Ano de Fabricação: ");
                        string anoFabricacaoString = Console.ReadLine();
                        int anoFabricacao;
                        bool ehAnoFabricacaoValido = int.TryParse(anoFabricacaoString, out anoFabricacao);

                        while (!ehAnoFabricacaoValido || anoFabricacao <= 0)
                        {
                            Console.WriteLine("Digite um número válido!");
                            Console.Write("Ano de Fabricação: ");
                            anoFabricacaoString = Console.ReadLine();
                            ehAnoFabricacaoValido = int.TryParse(anoFabricacaoString, out anoFabricacao);
                        }

                        string tipoVeiculo;
                        do
                        {
                            Console.Write("Tipo de Veículo | M - Motocicleta | A - Automóvel | C - Caminhão : ");
                            tipoVeiculo = Console.ReadLine();
                        } while (tipoVeiculo.ToUpper() != "M" && tipoVeiculo.ToUpper() != "A" && tipoVeiculo.ToUpper() != "C");

                        if (tipoVeiculo.ToUpper() == "M")
                        {
                            Veiculo novoVeiculo = new Moto(placaVeiculo, marcaVeiculo, modeloVeiculo, anoFabricacao);
                            Veiculos.Add(novoVeiculo);
                        }
                        else if (tipoVeiculo.ToUpper() == "A")
                        {
                            Veiculo novoVeiculo = new Carro(placaVeiculo, marcaVeiculo, modeloVeiculo, anoFabricacao);
                            Veiculos.Add(novoVeiculo);
                        }
                        else
                        {
                            Veiculo novoVeiculo = new Caminhao(placaVeiculo, marcaVeiculo, modeloVeiculo, anoFabricacao);
                            Veiculos.Add(novoVeiculo);
                        }

                        Console.WriteLine("Veículo cadastrado com sucesso.");
                        Console.WriteLine();
                        placaVeiculo = "";
                        marcaVeiculo = "";
                        modeloVeiculo = "";
                        anoFabricacao = 0;
                        break;

                    // Listar veículos
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("=== Listar Veículo ===");
                        foreach (Veiculo veiculo in Veiculos)
                        {
                            Console.WriteLine(veiculo.ApresentarDadosVeiculo());
                        }
                        Console.WriteLine();
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
                        Console.WriteLine("=== Cadastrar Peça ===");

                        Console.Write("Descrição: ");
                        string nomePeca = Console.ReadLine();

                        Console.Write("Estoque Disponível: ");
                        string estoqueDisponivelString = Console.ReadLine();
                        int estoqueDisponivel;
                        bool ehEstoqueDisponivelValido = int.TryParse(estoqueDisponivelString, out estoqueDisponivel);

                        while (!ehEstoqueDisponivelValido || estoqueDisponivel <= 0)
                        {
                            Console.WriteLine("Digite um número válido!");
                            Console.Write("Ano de Fabricação: ");
                            estoqueDisponivelString = Console.ReadLine();
                            ehEstoqueDisponivelValido = int.TryParse(estoqueDisponivelString, out estoqueDisponivel);
                        }

                        Console.Write("Preço Unitário R$: ");
                        string precoUnitarioString = Console.ReadLine();
                        decimal precoUnitario;
                        bool ehPrecoUnitarioValido = decimal.TryParse(precoUnitarioString, out precoUnitario);

                        while (!ehPrecoUnitarioValido || precoUnitario <= 0)
                        {
                            Console.WriteLine("Digite um número válido!");
                            Console.Write("Ano de Fabricação: ");
                            precoUnitarioString = Console.ReadLine();
                            ehPrecoUnitarioValido = decimal.TryParse(precoUnitarioString, out precoUnitario);
                        }

                        Peca novaPeca = new Peca(Pecas.Count + 1, nomePeca, estoqueDisponivel, precoUnitario);
                        Console.WriteLine();
                        break;

                    // Repor estoque
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("=== Reposição de Estoque ===");
                        Console.Write("Informe o ID do Produto: ");
                        string idProdutoString = Console.ReadLine();
                        int idProduto;
                        bool ehIDProdutoValido = int.TryParse(idProdutoString, out idProduto);

                        while (!ehIDProdutoValido || idProduto <= 0)
                        {
                            Console.WriteLine("Digite um número válido!");
                            Console.Write("Informe o ID do Produto: ");
                            idProdutoString = Console.ReadLine();
                            ehPrecoUnitarioValido = int.TryParse(idProdutoString, out idProduto);
                        }

                        Console.Write("Quantidade para repor: ");
                        string qtdReposicaoString = Console.ReadLine();
                        int qtdReposicao;
                        bool ehQtdReposicaoValida = int.TryParse(qtdReposicaoString, out qtdReposicao);

                        while (!ehQtdReposicaoValida || qtdReposicao <= 0)
                        {
                            Console.WriteLine("Digite um número válido!");
                            Console.Write("Quantidade para repor: ");
                            qtdReposicaoString = Console.ReadLine();
                            ehQtdReposicaoValida = int.TryParse(qtdReposicaoString, out qtdReposicao);
                        }

                        Peca pecaReposicao = Pecas.FirstOrDefault(p => p.Id == idProduto);
                        string nome_Peca = pecaReposicao.Nome;
                        Pecas[pecaReposicao.Id].ReporEstoque(pecaReposicao, qtdReposicao);

                        Console.WriteLine($"Incluído {qtdReposicao} unidades de estoque para o produto {nome_Peca}.");
                        Console.WriteLine();
                        break;

                    // Visualizar estoque
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("=== Visualização do Estoque ===");
                        foreach (Peca peca in Pecas)
                        {
                            Console.WriteLine($"Descrição: {peca.Nome} | Estoque: {peca.QtdEstoque} | Valor unitário: {peca.PrecoUnitario:C2}");
                        }
                        Console.WriteLine();
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
                        Console.WriteLine("=== Cadastrar Serviço ===");
                        Console.Write("Descrição do Serviço: ");
                        string descricaoServico = Console.ReadLine();

                        Console.Write("Informe o Valor Base por Hora: ");
                        decimal valorBaseServico;
                        string valorBaseServicoString = Console.ReadLine();
                        bool ehValorServicoValido = decimal.TryParse(valorBaseServicoString, out valorBaseServico);

                        while (!ehValorServicoValido || valorBaseServico <= 0)
                        {
                            Console.WriteLine("Digite um número válido!");
                            Console.Write("Informe o Valor Base por Hora: ");
                            valorBaseServicoString = Console.ReadLine();
                            ehValorServicoValido = decimal.TryParse(valorBaseServicoString, out valorBaseServico);
                        }

                        Console.Write("Informe o Tempo Estimado em Horas: ");
                        decimal tempoEstimadoServico;
                        string tempoEstimadoServicoString = Console.ReadLine();
                        bool ehTempoEstimadoValido = decimal.TryParse(tempoEstimadoServicoString, out tempoEstimadoServico);

                        while (!ehTempoEstimadoValido || tempoEstimadoServico <= 0)
                        {
                            Console.WriteLine("Digite um número válido!");
                            Console.Write("Informe o Tempo Estimado em Horas: ");
                            tempoEstimadoServicoString = Console.ReadLine();
                            ehTempoEstimadoValido = decimal.TryParse(tempoEstimadoServicoString, out tempoEstimadoServico);
                        }

                        Servico novoServico = new Servico(Servicos.Count + 1, descricaoServico, valorBaseServico, tempoEstimadoServico);
                        Servicos.Add(novoServico);
                        Console.WriteLine("Serviço cadastrado com sucesso.");
                        descricaoServico = "";
                        valorBaseServico = 0;
                        tempoEstimadoServico = 0;
                        Console.WriteLine();
                        break;

                    // Listar serviços
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("=== Listar Serviços ===");
                        foreach (Servico servico in Servicos)
                        {
                            Console.WriteLine($"Descrição: {servico.Nome} | Tempo em Horas: {servico.TempoEstimadoHoras} | Valor Hora: {servico.ValorBase:C2}");
                        }
                        Console.WriteLine();
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
                        Console.WriteLine("=== Criar novo Agendamento ===");
                        int idDoCliente;
                        Console.Write("ID do Cliente: ");
                        string idDoClienteString = Console.ReadLine();
                        bool ehIdValida = int.TryParse(idDoClienteString, out idDoCliente);
                        Cliente clienteSelecionado = Clientes.FirstOrDefault(c => c.Id == idDoCliente);
                        while (clienteSelecionado == null)
                        {
                            Console.WriteLine("Informe uma ID válida!");
                            Console.Write("ID do Cliente: ");
                            idDoClienteString = Console.ReadLine();
                            ehIdValida = int.TryParse(idDoClienteString, out idDoCliente);
                            clienteSelecionado = Clientes.FirstOrDefault(c => c.Id == idDoCliente);
                        }

                        Console.Write("Placa do Veículo: ");
                        string placaDoVeiculo = Console.ReadLine();
                        Veiculo veiculoSelecionado = Veiculos.FirstOrDefault(v => v.Placa == placaDoVeiculo.ToUpper());

                        while (veiculoSelecionado == null)
                        {
                            Console.WriteLine("Informe um veículo válido!");
                            Console.Write("Placa do Veículo: ");
                            placaDoVeiculo = Console.ReadLine();
                            veiculoSelecionado = Veiculos.FirstOrDefault(v => v.Placa == placaDoVeiculo.ToUpper());
                        }

                        Console.Write("Data e Hora do Agendamento (DD/MM/AAAA HH:MM): ");
                        DateTime dataHoraAgendamento;
                        string dataHoraAgendamentoString = Console.ReadLine();
                        bool ehDataValida = DateTime.TryParse(dataHoraAgendamentoString, out dataHoraAgendamento);

                        while (!ehDataValida || dataHoraAgendamento == null)
                        {
                            Console.WriteLine("Digite uma data válida!");
                            Console.Write("Data e Hora do Agendamento (DD/MM/AAAA HH:MM): ");
                            dataHoraAgendamentoString = Console.ReadLine();
                            ehDataValida = DateTime.TryParse(dataHoraAgendamentoString, out dataHoraAgendamento);
                        }

                        string maisServicos = "";
                        int idDoServico;
                        List<Servico> ServicosSelecionados = [];

                        while (maisServicos.ToUpper() != "N")
                        {
                            Console.Write("ID do Serviço: ");
                            string idDoServicoString = Console.ReadLine();
                            bool ehIdServicoValida = int.TryParse(idDoServicoString, out idDoServico);
                            Servico servicoParaAddOS = Servicos.FirstOrDefault(s => s.Id == idDoServico);

                            while (servicoParaAddOS == null)
                            {
                                Console.WriteLine("Informe um ID de Serviço válido!");
                                Console.Write("ID do Serviço: ");
                                idDoServicoString = Console.ReadLine();
                                ehIdServicoValida = int.TryParse(idDoServicoString, out idDoServico);
                                servicoParaAddOS = Servicos.FirstOrDefault(s => s.Id == idDoServico);
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
                            Peca pecasParaAddOS = Pecas.FirstOrDefault(p => p.Id == idDaPeca);

                            while (pecasParaAddOS == null)
                            {
                                Console.WriteLine("Digite um ID de Peça válido!");
                                Console.Write("ID da Peça: ");
                                idDaPecaString = Console.ReadLine();
                                ehIdPecaValida = int.TryParse(idDaPecaString, out idDaPeca);
                                pecasParaAddOS = Pecas.FirstOrDefault(p => p.Id == idDaPeca);
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

                        Agendamento novoAgendamento = new Agendamento(Agendamentos.Count + 1, clienteSelecionado, veiculoSelecionado,
                            ServicosSelecionados, PecasSelecionadas, dataHoraAgendamento, StatusOrdemServico.Agendada);

                        try
                        {
                            bool possuiConflito = Agendamentos.Any(a => a.ConflitaCom(novoAgendamento));
                        }
                        catch (HorarioIndisponivelException ex)
                        {
                            Console.WriteLine("Conflito de Agenda! " + ex.Message);
                            Console.WriteLine();
                            break;
                        }

                        Agendamentos.Add(novoAgendamento);
                        Console.WriteLine("Agendamento realizado com sucesso.");
                        Console.WriteLine();
                        break;

                    // Cancelar agendamento
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("=== Cancelar Agendamento ===");
                        Console.Write("Informe o número do Agendamento: ");
                        int ordemServico;
                        string ordemServicoString = Console.ReadLine();
                        bool ehOSValida = int.TryParse(ordemServicoString, out ordemServico);
                        Agendamento agendamentoParaCancelar = Agendamentos.FirstOrDefault(a => a.Id == ordemServico);

                        while (agendamentoParaCancelar == null)
                        {
                            Console.WriteLine("Informe um Agendamento válido!");
                            Console.Write("Informe o número do Agendamento: ");
                            ordemServicoString = Console.ReadLine();
                            ehOSValida = int.TryParse(ordemServicoString, out ordemServico);
                            agendamentoParaCancelar = Agendamentos.FirstOrDefault(a => a.Id == ordemServico);
                        }

                        Console.WriteLine();
                        agendamentoParaCancelar.DetalharAgendamento();

                        string confirmaCancelamento = "";
                        Console.WriteLine();
                        Console.Write("Confirma o Cancelamento do agendamento? (S | N): ");
                        confirmaCancelamento = Console.ReadLine();

                        while (confirmaCancelamento.ToUpper() != "S" && confirmaCancelamento.ToUpper() != "N")
                        {
                            Console.WriteLine("Opção inválida!");
                            Console.Write("Confirma o Cancelamento do agendamento? (S | N): ");
                            confirmaCancelamento = Console.ReadLine();
                        }

                        if (confirmaCancelamento.ToUpper() == "S")
                        {
                            Agendamentos.FirstOrDefault(a => a.Id == ordemServico).CancelarAgendamento();
                            Console.WriteLine("Agendamento cancelado com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("Agendamento não foi cancelado.");
                        }

                        Console.WriteLine();
                        break;

                    // Listar agendamentos
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("=== Listar Agendamentos ===");
                        foreach (Agendamento agendamento in Agendamentos)
                        {
                            Console.WriteLine();
                            agendamento.DetalharAgendamento();
                        }
                        Console.WriteLine();
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
                        Console.WriteLine("=== Criar nova Ordem de Serviço ===");
                        int idDoCliente;
                        Console.Write("ID do Cliente: ");
                        string idDoClienteString = Console.ReadLine();
                        bool ehIdValida = int.TryParse(idDoClienteString, out idDoCliente);
                        Cliente clienteSelecionado = Clientes.FirstOrDefault(c => c.Id == idDoCliente);

                        while (clienteSelecionado == null)
                        {
                            Console.WriteLine("Digite um ID de Cliente válido!");
                            Console.Write("ID do Cliente: ");
                            idDoClienteString = Console.ReadLine();
                            ehIdValida = int.TryParse(idDoClienteString, out idDoCliente);
                            clienteSelecionado = Clientes.FirstOrDefault(c => c.Id == idDoCliente);
                        }

                        Console.Write("Placa do Veículo: ");
                        string placaDoVeiculo = Console.ReadLine();
                        Veiculo veiculoSelecionado = Veiculos.FirstOrDefault(v => v.Placa == placaDoVeiculo.ToUpper());

                        while (veiculoSelecionado == null)
                        {
                            Console.WriteLine("Informe um veículo válido!");
                            Console.Write("Placa do Veículo: ");
                            placaDoVeiculo = Console.ReadLine();
                            veiculoSelecionado = Veiculos.FirstOrDefault(v => v.Placa == placaDoVeiculo.ToUpper());
                        }

                        Console.Write("ID do Funcionário: ");
                        int idDoFuncionario;
                        string idDoFuncionarioString = Console.ReadLine();
                        bool ehIdFuncionarioValida = int.TryParse(idDoFuncionarioString, out idDoFuncionario);
                        Funcionario funcionarioSelecionado = Funcionarios.FirstOrDefault(c => c.Id == idDoFuncionario);

                        while (funcionarioSelecionado == null)
                        {
                            Console.WriteLine("Informe um ID de funcionário válido!");
                            Console.Write("ID do Funcionário: ");
                            idDoFuncionarioString = Console.ReadLine();
                            ehIdFuncionarioValida = int.TryParse(idDoFuncionarioString, out idDoFuncionario);
                            funcionarioSelecionado = Funcionarios.FirstOrDefault(c => c.Id == idDoFuncionario);
                        }

                        string maisServicos = "";
                        int idDoServico;
                        List<Servico> ServicosSelecionados = [];

                        while (maisServicos.ToUpper() != "N")
                        {
                            Console.Write("ID do Serviço: ");
                            string idDoServicoString = Console.ReadLine();
                            bool ehIdServicoValida = int.TryParse(idDoServicoString, out idDoServico);
                            Servico servicoParaAddOS = Servicos.FirstOrDefault(s => s.Id == idDoServico);

                            while (servicoParaAddOS == null)
                            {
                                Console.WriteLine("Informe um ID de Serviço válido!");
                                Console.Write("ID do Serviço: ");
                                idDoServicoString = Console.ReadLine();
                                ehIdServicoValida = int.TryParse(idDoServicoString, out idDoServico);
                                servicoParaAddOS = Servicos.FirstOrDefault(s => s.Id == idDoServico);
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
                            Peca pecasParaAddOS = Pecas.FirstOrDefault(p => p.Id == idDaPeca);

                            while (pecasParaAddOS == null)
                            {
                                Console.WriteLine("Digite um ID de Peça válido!");
                                Console.Write("ID da Peça: ");
                                idDaPecaString = Console.ReadLine();
                                ehIdPecaValida = int.TryParse(idDaPecaString, out idDaPeca);
                                pecasParaAddOS = Pecas.FirstOrDefault(p => p.Id == idDaPeca);
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

                        OrdemServico novaOrdemDeServico = new OrdemServico(OrdensDeServico.Count + 1, clienteSelecionado, veiculoSelecionado,
                            funcionarioSelecionado, ServicosSelecionados, PecasSelecionadas, DateTime.UtcNow, statusOrdem);
                        OrdensDeServico.Add(novaOrdemDeServico);
                        Console.WriteLine("Ordem de Serviço criada com sucesso.");
                        Console.WriteLine();
                        break;

                    // Adicionar serviço
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("=== Adicionar um Serviço à O.S. ===");
                        string desejaAddMaisServicos = "";
                        int idServicoAdicionar;
                        List<Servico> ServicosParaAdicionar = [];

                        Console.Write("Número da Ordem de Serviço: ");
                        string ordemDeServicoString = Console.ReadLine();
                        int ordemDeServicoAdicionar;
                        bool ehNroOrdemServicoValida = int.TryParse(ordemDeServicoString, out ordemDeServicoAdicionar);
                        OrdemServico OSadicionar = OrdensDeServico.FirstOrDefault(os => os.Id == ordemDeServicoAdicionar);

                        while (OSadicionar == null)
                        {
                            Console.WriteLine("Informe uma Ordem de Serviço válida!");
                            Console.Write("Número da Ordem de Serviço: ");
                            ordemDeServicoString = Console.ReadLine();
                            ehNroOrdemServicoValida = int.TryParse(ordemDeServicoString, out ordemDeServicoAdicionar);
                            OSadicionar = OrdensDeServico.FirstOrDefault(os => os.Id == ordemDeServicoAdicionar);
                        }

                        while (desejaAddMaisServicos.ToUpper() != "N")
                        {
                            Console.Write("ID do Serviço: ");
                            string idServicoAdicionarString = Console.ReadLine();
                            bool ehIdServicoValida = int.TryParse(idServicoAdicionarString, out idServicoAdicionar);
                            Servico servicoParaAddOS = Servicos.FirstOrDefault(s => s.Id == idServicoAdicionar);

                            while (servicoParaAddOS == null)
                            {
                                Console.WriteLine("Informe um ID de Serviço válido!");
                                Console.Write("ID do Serviço: ");
                                idServicoAdicionarString = Console.ReadLine();
                                ehIdServicoValida = int.TryParse(idServicoAdicionarString, out idServicoAdicionar);
                                servicoParaAddOS = Servicos.FirstOrDefault(s => s.Id == idServicoAdicionar);
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
                        break;

                    // Adicionar peça
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("=== Adicionar Peça à uma O.S. ===");
                        string desejaAddMaisPecas = "";
                        int idPecaAdicionar;
                        List<Peca> PecasParaAdicionar = [];

                        Console.Write("Número da Ordem de Serviço: ");
                        ordemDeServicoString = Console.ReadLine();
                        ordemDeServicoAdicionar = 0;
                        ehNroOrdemServicoValida = int.TryParse(ordemDeServicoString, out ordemDeServicoAdicionar);
                        OSadicionar = OrdensDeServico.FirstOrDefault(os => os.Id == ordemDeServicoAdicionar);

                        while (OSadicionar == null)
                        {
                            Console.WriteLine("Informe uma Ordem de Serviço válida!");
                            Console.Write("Número da Ordem de Serviço: ");
                            ordemDeServicoString = Console.ReadLine();
                            ehNroOrdemServicoValida = int.TryParse(ordemDeServicoString, out ordemDeServicoAdicionar);
                            OSadicionar = OrdensDeServico.FirstOrDefault(os => os.Id == ordemDeServicoAdicionar);
                        }

                        maisPecas = "";
                        idDaPeca = 0;
                        PecasSelecionadas = [];

                        while (maisPecas.ToUpper() != "N")
                        {
                            Console.Write("ID da Peça: ");
                            string idDaPecaString = Console.ReadLine();
                            bool ehIdPecaValida = int.TryParse(idDaPecaString, out idDaPeca);
                            Peca pecasParaAddOS = Pecas.FirstOrDefault(p => p.Id == idDaPeca);

                            while (pecasParaAddOS == null)
                            {
                                Console.WriteLine("Informe um ID de Peça válido!");
                                Console.Write("ID da Peça: ");
                                idDaPecaString = Console.ReadLine();
                                ehIdPecaValida = int.TryParse(idDaPecaString, out idDaPeca);
                                pecasParaAddOS = Pecas.FirstOrDefault(p => p.Id == idDaPeca);
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

                        foreach (Peca pecaParaAdicionar in PecasParaAdicionar)
                        {
                            OSadicionar.ListaPecas.Add(pecaParaAdicionar);
                        }
                        Console.WriteLine("Peça(s) adicionada(s) com sucesso.");
                        Console.WriteLine();
                        break;

                    // Finalizar ordem
                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("=== Fechar Ordem de Serviço ===");
                        Console.Write("Número da Ordem de Serviço: ");
                        ordemDeServicoString = Console.ReadLine();
                        int ordemDeServicoEmEdicao = 0;
                        ehNroOrdemServicoValida = int.TryParse(ordemDeServicoString, out ordemDeServicoEmEdicao);
                        OrdemServico OrdemDeServicoEmEdicao = OrdensDeServico.FirstOrDefault(os => os.Id == ordemDeServicoEmEdicao);

                        while (OrdemDeServicoEmEdicao == null)
                        {
                            Console.WriteLine("Informe uma Ordem de Serviço válida!");
                            Console.Write("Número da Ordem de Serviço: ");
                            ordemDeServicoString = Console.ReadLine();
                            ehNroOrdemServicoValida = int.TryParse(ordemDeServicoString, out ordemDeServicoEmEdicao);
                            OrdemDeServicoEmEdicao = OrdensDeServico.FirstOrDefault(os => os.Id == ordemDeServicoEmEdicao);
                        }

                        OrdemDeServicoEmEdicao.FinalizarOrdemServico();
                        Console.WriteLine($"Ordem de Serviço nº {ordemDeServicoEmEdicao} foi finalizada com sucesso.");

                        NotificacaoWPP notificacao = new NotificacaoWPP();
                        string mensagem = $"Olá, {OrdemDeServicoEmEdicao.Cliente.Nome}, tudo bem? Estamos passando para avisa-lo que os reparos no seu veículo {OrdemDeServicoEmEdicao.Veiculo.Marca} {OrdemDeServicoEmEdicao.Veiculo.Modelo} foram concluídos.";
                        notificacao.ConclusaoOrdemDeServicoAsync(mensagem);

                        Console.WriteLine();
                        break;

                    // Cancelar ordem
                    case 5:
                        Console.WriteLine();
                        Console.WriteLine("=== Cancelar Ordem de Serviço ===");
                        Console.Write("Número da Ordem de Serviço: ");
                        ordemDeServicoString = Console.ReadLine();
                        ordemDeServicoEmEdicao = 0;
                        ehNroOrdemServicoValida = int.TryParse(ordemDeServicoString, out ordemDeServicoEmEdicao);
                        OrdemDeServicoEmEdicao = OrdensDeServico.FirstOrDefault(os => os.Id == ordemDeServicoEmEdicao);

                        while (OrdemDeServicoEmEdicao == null)
                        {
                            Console.WriteLine("Informe uma Ordem de Serviço válida!");
                            Console.Write("Número da Ordem de Serviço: ");
                            ordemDeServicoString = Console.ReadLine();
                            ehNroOrdemServicoValida = int.TryParse(ordemDeServicoString, out ordemDeServicoEmEdicao);
                            OrdemDeServicoEmEdicao = OrdensDeServico.FirstOrDefault(os => os.Id == ordemDeServicoEmEdicao);
                        }

                        OrdemDeServicoEmEdicao.CancelarOrdemServico();
                        Console.WriteLine($"Ordem de Serviço nº {ordemDeServicoEmEdicao} foi cancelada.");
                        Console.WriteLine();
                        break;

                    // Listar ordens
                    case 6:
                        Console.WriteLine();
                        Console.WriteLine("=== Listar Ordens de Serviço ===");
                        foreach (OrdemServico ordemServico in OrdensDeServico)
                        {
                            Console.WriteLine();
                            ordemServico.DetalharOrdemServico();
                        }
                        Console.WriteLine();
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
                        Console.WriteLine();
                        Console.WriteLine("=== Relatório | Faturamento Total ===");
                        decimal totalFaturadoPeca = OrdensDeServico
                            .Where(os => os.Status != StatusOrdemServico.Cancelada)
                            .SelectMany(os => os.ListaPecas)
                            .Sum(p => p.PrecoUnitario);

                        decimal totalFaturadoServico = OrdensDeServico
                            .Where(os => os.Status != StatusOrdemServico.Cancelada)
                            .SelectMany(os => os.ListaServicos)
                            .Sum(p => p.ValorBase * p.TempoEstimadoHoras);

                        decimal faturamentoTotal = totalFaturadoPeca + totalFaturadoServico;

                        Console.WriteLine($"Total Peças: {totalFaturadoPeca:C2}");
                        Console.WriteLine($"Total Serviços: {totalFaturadoServico:C2}");
                        Console.WriteLine($"Total Faturado: {faturamentoTotal:C2}");
                        Console.WriteLine();
                        break;

                    // Serviços mais executados
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("=== Relatório | Serviços mais vendidos ===");
                        var ServicosMaisExecutados = OrdensDeServico
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
                        break;

                    // Clientes que mais gastaram
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("=== Relatório | Top Clientes por Faturamento ===");
                        var ClientesMaiorFaturamento = OrdensDeServico
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
                        break;

                    // Peças mais utilizadas
                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("=== Relatório | Peças mais vendidas ===");
                        var PecasMaisVendidas = OrdensDeServico
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
                        break;

                    // Ordens em andamento
                    case 5:
                        Console.WriteLine();
                        var OrdensServicoEmAndamento = OrdensDeServico.Where(os => os.Status == StatusOrdemServico.EmAndamento).Count();
                        Console.WriteLine($"=== Relatório | OS's em andamento: {OrdensServicoEmAndamento} ===");
                        Console.WriteLine();
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
                        Console.WriteLine();
                        Console.WriteLine("=== Notificação | Confirmar Agendamento ===");
                        List<Agendamento> agendamentosParaConfirmar = Agendamentos.Where(a => a.Status == StatusOrdemServico.Agendada).ToList();

                        foreach (Agendamento agendamento in agendamentosParaConfirmar)
                        {
                            string mensagem = $"Olá, {agendamento.Cliente.Nome}, tudo bem? Seu veículo {agendamento.Veiculo.Marca} {agendamento.Veiculo.Modelo} tem um horário agendado para {agendamento.DataAgendamento}. Por gentileza poderia confirmar?";
                            notificacao.ConfirmarAgendamentosAsync(mensagem);
                        }
                        Console.WriteLine();
                        break;

                    // Enviar conclusão de serviço
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("=== Notificação | Conclusão da O.S. ===");
                        List<OrdemServico> ordensDeServicoFinalizadas = OrdensDeServico.Where(a => a.Status == StatusOrdemServico.Finalizada).ToList();

                        foreach (OrdemServico ordemServico in ordensDeServicoFinalizadas)
                        {
                            string mensagem = $"Olá, {ordemServico.Cliente.Nome}, tudo bem? Estamos passando para avisa-lo que os reparos no seu veículo {ordemServico.Veiculo.Marca} {ordemServico.Veiculo.Modelo} foram concluídos.";
                            notificacao.ConclusaoOrdemDeServicoAsync(mensagem);
                        }
                        Console.WriteLine();
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