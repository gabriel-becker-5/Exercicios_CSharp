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
    new Peca(1, "Bieleta", 1, 100.50m),
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
        StatusOrdemServico.AguardandoPecas
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
    ),
};


List<Agendamento> Agendamentos = new List<Agendamento>
{
    new Agendamento(
        1,
        Clientes.First(p => p.Id == 6),
        Veiculos.FirstOrDefault(v => v.Placa == "AAA-0A15"),
        DateTime.UtcNow,
        Servicos.Where(s => s.Id == 3 || s.Id == 5).ToList(),
        Pecas.Where(pe => pe.Id == 2 || pe.Id == 10).ToList()
    ),

    new Agendamento(
    2,
    Clientes.First(c => c.Id == 1),
    Veiculos.First(v => v.Placa == "AAA-0A05"),
    DateTime.UtcNow.AddHours(2),
    Servicos.Where(s => s.Id == 1 || s.Id == 2).ToList(),
    Pecas.Where(p => p.Id == 14).ToList()
    ),

    new Agendamento(
        3,
        Clientes.First(c => c.Id == 3),
        Veiculos.First(v => v.Placa == "AAA-0A02"),
        DateTime.UtcNow.AddDays(1),
        Servicos.Where(s => s.Id == 4 || s.Id == 5).ToList(),
        Pecas.Where(p => p.Id >= 1 && p.Id <= 5).ToList()
    ),

    new Agendamento(
        4,
        Clientes.First(c => c.Id == 5),
        Veiculos.First(v => v.Placa == "AAA-0A11"),
        DateTime.UtcNow.AddHours(5),
        Servicos.Where(s => s.Id == 7).ToList(),
        Pecas.Where(p => p.Id == 6 || p.Id == 7).ToList()
    ),

    new Agendamento(
        5,
        Clientes.First(c => c.Id == 2),
        Veiculos.First(v => v.Placa == "AAA-0A09"),
        DateTime.UtcNow.AddDays(2),
        Servicos.Where(s => s.Id == 3).ToList(),
        Pecas.Where(p => p.Id == 2).ToList()
    ),

    new Agendamento(
        6,
        Clientes.First(c => c.Id == 4),
        Veiculos.First(v => v.Placa == "AAA-0A04"),
        DateTime.UtcNow.AddDays(3),
        Servicos.Where(s => s.Id >= 1 && s.Id <= 4).ToList(),
        Pecas.Where(p => p.Id >= 8 && p.Id <= 12).ToList()
    ),

    new Agendamento(
        7,
        Clientes.First(p => p.Id == 6),
        Veiculos.FirstOrDefault(v => v.Placa == "AAA-0A15"),
        DateTime.UtcNow,
        Servicos.Where(s => s.Id == 3 || s.Id == 5).ToList(),
        Pecas.Where(pe => pe.Id == 2 || pe.Id == 10).ToList()
    ),

    new Agendamento(
    8,
    Clientes.First(c => c.Id == 1),
    Veiculos.First(v => v.Placa == "AAA-0A05"),
    DateTime.UtcNow.AddHours(2),
    Servicos.Where(s => s.Id == 1 || s.Id == 2).ToList(),
    Pecas.Where(p => p.Id == 14).ToList()
    ),

    new Agendamento(
        9,
        Clientes.First(c => c.Id == 3),
        Veiculos.First(v => v.Placa == "AAA-0A02"),
        DateTime.UtcNow.AddDays(1),
        Servicos.Where(s => s.Id == 4 || s.Id == 5).ToList(),
        Pecas.Where(p => p.Id >= 1 && p.Id <= 5).ToList()
    ),

    new Agendamento(
        10,
        Clientes.First(c => c.Id == 5),
        Veiculos.First(v => v.Placa == "AAA-0A11"),
        DateTime.UtcNow.AddHours(5),
        Servicos.Where(s => s.Id == 7).ToList(),
        Pecas.Where(p => p.Id == 6 || p.Id == 7).ToList()
    ),

    new Agendamento(
        11,
        Clientes.First(c => c.Id == 2),
        Veiculos.First(v => v.Placa == "AAA-0A09"),
        DateTime.UtcNow.AddDays(2),
        Servicos.Where(s => s.Id == 3).ToList(),
        Pecas.Where(p => p.Id == 2).ToList()
    ),

    new Agendamento(
        12,
        Clientes.First(c => c.Id == 4),
        Veiculos.First(v => v.Placa == "AAA-0A04"),
        DateTime.UtcNow.AddDays(3),
        Servicos.Where(s => s.Id >= 1 && s.Id <= 4).ToList(),
        Pecas.Where(p => p.Id >= 8 && p.Id <= 12).ToList()
    ),

    new Agendamento(
        13,
        Clientes.First(p => p.Id == 6),
        Veiculos.FirstOrDefault(v => v.Placa == "AAA-0A15"),
        DateTime.UtcNow,
        Servicos.Where(s => s.Id == 3 || s.Id == 5).ToList(),
        Pecas.Where(pe => pe.Id == 2 || pe.Id == 10).ToList()
    ),

    new Agendamento(
    14,
    Clientes.First(c => c.Id == 1),
    Veiculos.First(v => v.Placa == "AAA-0A05"),
    DateTime.UtcNow.AddHours(2),
    Servicos.Where(s => s.Id == 1 || s.Id == 2).ToList(),
    Pecas.Where(p => p.Id == 14).ToList()
    ),

    new Agendamento(
        15,
        Clientes.First(c => c.Id == 3),
        Veiculos.First(v => v.Placa == "AAA-0A02"),
        DateTime.UtcNow.AddDays(1),
        Servicos.Where(s => s.Id == 4 || s.Id == 5).ToList(),
        Pecas.Where(p => p.Id >= 1 && p.Id <= 5).ToList()
    ),

    new Agendamento(
        16,
        Clientes.First(c => c.Id == 5),
        Veiculos.First(v => v.Placa == "AAA-0A11"),
        DateTime.UtcNow.AddHours(5),
        Servicos.Where(s => s.Id == 7).ToList(),
        Pecas.Where(p => p.Id == 6 || p.Id == 7).ToList()
    ),

    new Agendamento(
        17,
        Clientes.First(c => c.Id == 2),
        Veiculos.First(v => v.Placa == "AAA-0A09"),
        DateTime.UtcNow.AddDays(2),
        Servicos.Where(s => s.Id == 3).ToList(),
        Pecas.Where(p => p.Id == 2).ToList()
    ),

    new Agendamento(
        18,
        Clientes.First(c => c.Id == 4),
        Veiculos.First(v => v.Placa == "AAA-0A04"),
        DateTime.UtcNow.AddDays(3),
        Servicos.Where(s => s.Id >= 1 && s.Id <= 4).ToList(),
        Pecas.Where(p => p.Id >= 8 && p.Id <= 12).ToList()
    )
};

int opcaoMenu = -1;
Console.WriteLine("=== Bem vindo ao Sistema de Gestão de Oficinas ===");

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
            Console.WriteLine("=== Menu de Estoque === ");
            while (opcaoMenu != 0)
            {
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
                            Console.Write("Informe o ID do Produto: ");
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
            Console.WriteLine("=== Menu de Serviços === ");
            while (opcaoMenu != 0)
            {
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
                        Console.WriteLine();
                        break;
                    // Listar serviços
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("=== Listar Serviços ===");
                        foreach (Servico servico in Servicos)
                        {
                            Console.WriteLine($"Descrição: {servico.Nome} | Tempo em Horas: {servico.TempoEstimadoHoras} | Valor: {servico.ValorBase:C2}");
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
            Console.WriteLine("=== Menu de Agendamentos === ");
            while (opcaoMenu != 0)
            {
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
                        Console.WriteLine();
                        break;
                    // Cancelar agendamento
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("=== Cancelar Agendamento ===");
                        Console.WriteLine();
                        break;
                    // Listar agendamentos
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("=== Listar Agendamentos ===");
                        foreach (Agendamento agendamento in Agendamentos)
                        {
                            Console.WriteLine($"==================== Ordem de Serviço: {agendamento.Id} ====================");
                            Console.WriteLine($"Hora: {agendamento.DataHora} | Cliente: {agendamento.Cliente.Nome} - {agendamento.Cliente.GetType().Name}");
                            Console.WriteLine($"Veículo: {agendamento.Veiculo.Placa} - {agendamento.Veiculo.Marca} {agendamento.Veiculo.Modelo} {agendamento.Veiculo.AnoFabricacao}");
                            Console.WriteLine("=========================================================");
                            Console.Write("| Relação de Peças: ");
                            foreach (Peca peca in agendamento.Peca)
                            {
                                try
                                {
                                    Console.Write($"{peca.Nome}, ");
                                }                  
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                finally
                                {
                                }
                            }
                            Console.WriteLine();
                            Console.Write("| Relação de Serviços: ");
                            foreach (Servico servico in agendamento.Servico)
                            {
                                try
                                {
                                    Console.Write($"{servico.Nome}, ");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                finally
                                {
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine("=========================================================");
                            Console.WriteLine();
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
            Console.WriteLine("=== Menu de Ordem de Serviço === ");
            while (opcaoMenu != 0)
            {
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
                        Console.WriteLine();
                        break;
                    // Adicionar serviço
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("=== Adicionar Serviço à uma O.S. ===");
                        Console.WriteLine();
                        break;
                    // Adicionar peça
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("=== Adicionar Peça à uma O.S. ===");
                        Console.WriteLine();
                        break;
                    // Finalizar ordem
                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("=== Fechar Ordem de Serviço ===");
                        Console.WriteLine();
                        break;
                    // Cancelar ordem
                    case 5:
                        Console.WriteLine();
                        Console.WriteLine("=== Cancelar Ordem de Serviço ===");
                        Console.WriteLine();
                        break;
                    // Listar ordens
                    case 6:
                        Console.WriteLine();
                        Console.WriteLine("=== Listar Ordens de Serviço ===");
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
            Console.WriteLine("=== Menu de Relatório === ");
            while (opcaoMenu != 0)
            {
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
                        Console.WriteLine();
                        break;
                    // Serviços mais executados
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("=== Relatório | Serviços mais vendidos ===");
                        Console.WriteLine();
                        break;
                    // Clientes que mais gastaram
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("=== Relatório | Top Clientes por Faturamento ===");
                        Console.WriteLine();
                        break;
                    // Peças mais utilizadas
                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("=== Relatório | Peças mais vendidas ===");
                        Console.WriteLine();
                        break;
                    // Ordens em andamento
                    case 5:
                        Console.WriteLine();
                        Console.WriteLine("=== Relatório | OS's em andamento ===");
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
            Console.WriteLine("=== Menu de Notificação === ");
            while (opcaoMenu != 0)
            {
                Console.WriteLine("1. Enviar confirmação de agendamento");
                Console.WriteLine("2. Enviar conclusão de serviço");
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
                    // Enviar confirmação de agendamento
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("=== Notificação | Confirmar Agendamento ===");
                        Console.WriteLine();
                        break;
                    // Enviar conclusão de serviço
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("=== Notificação | Conclusão da O.S. ===");
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