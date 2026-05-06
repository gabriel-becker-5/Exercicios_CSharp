using Aula_11_Poo;
using static System.Runtime.InteropServices.JavaScript.JSType;
int inputMenu;

Console.WriteLine("Exercícios POO - Aula 11");
Console.WriteLine("1. Carro");
Console.WriteLine("2. Pessoa");
Console.WriteLine("3. Produto");
Console.WriteLine("4. ContaBancaria");
Console.WriteLine("5. Aluno");

Console.Write("Digite a opção para acessar: ");
inputMenu = int.Parse(Console.ReadLine());

switch (inputMenu)
{
    case 1:
        Carro carro1 = new Carro()
        {
            Marca = "Renault",
            Modelo = "Kwid"
        };
        carro1.ExibirDadosCarro();
        break;

    case 2:
        int qtdMaxPessoas = 3;
        Pessoa[] pessoas = new Pessoa[qtdMaxPessoas];

        pessoas[0] = new Pessoa { Nome = "Gabriel 1", Idade = 30 };
        pessoas[1] = new Pessoa { Nome = "Gabriel 2", Idade = 31 };
        pessoas[2] = new Pessoa { Nome = "Gabriel 3", Idade = 32 };

        Console.Write("Informe um nome para pesquisar: ");
        string nomePesquisa = Console.ReadLine();
        Pessoa pesquisar = new Pessoa();

        if (pesquisar.EhCadastrado(pessoas, nomePesquisa))
        {
            Console.WriteLine("Pessoa encontrada!");
        }
        else
        {
            Console.WriteLine("Pessoa não encontrada.");
        }

        break;

    case 3:
        int qtdMaxProdutos = 3;
        Produto[] produtos = new Produto[qtdMaxProdutos];

        produtos[0] = new Produto
        {
            Nome = "Ventilador 220v",
            Preco = 3m
        };

        produtos[1] = new Produto
        {
            Nome = "Ventilador 110v",
            Preco = 1m
        };

        produtos[2] = new Produto
        {
            Nome = "Ventilador de Teto",
            Preco = 2m
        };

        for (int i = 0; i < produtos.Length; i++)
        {
            Console.WriteLine($"Produto: {produtos[i].Nome} | Preço: R$ {produtos[i].Preco}");
        }

        Console.WriteLine("=== Produto Mais Caro em Estoque ===");
        Produto maisCaro = new Produto();
        produtos[maisCaro.ObterPosicaoProdMaiscaro(produtos)].ExibirDadosProduto();

        break;

    case 4:
        ContaBancaria BuscarConta(ContaBancaria[] contasBancarias, int numero)
        {
            for (int i = 0; i < contasBancarias.Length; i++)
            {
                if (contasBancarias[i] != null && contasBancarias[i].NumeroConta == numero)
                {
                    return contasBancarias[i];
                }
            }
            return null;
        }

        int opcaoMenuBanco;
        int qtdMaxContas = 5;
        ContaBancaria[] contasBancarias = new ContaBancaria[qtdMaxContas];

        Console.WriteLine("===  Olá, seja bem vindo ao Banco Entra21  ===");
        Console.WriteLine("1. Criar Conta");
        Console.WriteLine("2. Depositar");
        Console.WriteLine("3. Sacar");
        Console.WriteLine("4. Ver Saldo");
        Console.WriteLine("5. Sair");
        Console.WriteLine("Informe a opção: ");
        opcaoMenuBanco = int.Parse(Console.ReadLine());
        int qtdContasCadastradas = 0;
        int proximoNumeroConta = 1;
        while (opcaoMenuBanco != 5)
        {
            switch (opcaoMenuBanco)
            {
                case 1:
                    if (qtdContasCadastradas < qtdMaxContas)
                    {
                        Console.WriteLine("Digite o nome do titular da conta: ");
                        string titularDaConta = Console.ReadLine();

                        for (int i = 0; i < contasBancarias.Length; i++)
                        {
                            if (contasBancarias[i] == null)
                            {
                                contasBancarias[i] = new ContaBancaria { Titular = titularDaConta, Saldo = 0.00m, NumeroConta = proximoNumeroConta };
                                qtdContasCadastradas++;
                                proximoNumeroConta++;
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não há espaço para mais contas!");
                    }
                    break;

                case 2:
                    Console.WriteLine("Número da conta para depositar: ");
                    int contaParaDeposito = int.Parse(Console.ReadLine());

                    ContaBancaria contaEncontrada = BuscarConta(contasBancarias, contaParaDeposito);

                    Console.WriteLine("Valor para depositar: ");
                    decimal valorParaDeposito = decimal.Parse(Console.ReadLine());

                    if (contaEncontrada != null)
                    {
                        contaEncontrada.Depositar(valorParaDeposito, contaEncontrada.NumeroConta);
                    }
                    else
                    {
                        Console.WriteLine("Conta não encontrada.");
                    }
                    break;

                case 3:
                    contaEncontrada = null;

                    Console.WriteLine("Número da conta para sacar: ");
                    int contaParaSaque = int.Parse(Console.ReadLine());
                    Console.WriteLine("Valor para sacar: ");
                    decimal valorParaSaque = decimal.Parse(Console.ReadLine());

                    for (int i = 0; i < contasBancarias.Length; i++)
                    {
                        if (contasBancarias[i] != null && contasBancarias[i].NumeroConta == contaParaSaque)
                        {
                            contaEncontrada = contasBancarias[i];
                            break;
                        }
                    }

                    if (contaEncontrada != null)
                    {
                        contaEncontrada.Sacar(valorParaSaque, contaEncontrada.NumeroConta);
                    }
                    else
                    {
                        Console.WriteLine("Conta não encontrada.");
                    }
                    break;

                case 4:
                    contaEncontrada = null;

                    Console.WriteLine("Número da conta: ");
                    int contaParaConsultar = int.Parse(Console.ReadLine());

                    for (int i = 0; i < contasBancarias.Length; i++)
                    {
                        if (contasBancarias[i] != null && contasBancarias[i].NumeroConta == contaParaConsultar)
                        {
                            contaEncontrada = contasBancarias[i];
                            break;
                        }
                    }

                    if (contaEncontrada != null)
                    {
                        contaEncontrada.ExibirSaldo(contaEncontrada.NumeroConta);
                    }
                    else
                    {
                        Console.WriteLine("Conta não encontrada.");
                    }
                    break;
            }

            Console.WriteLine("1. Criar Conta");
            Console.WriteLine("2. Depositar");
            Console.WriteLine("3. Sacar");
            Console.WriteLine("4. Ver Saldo");
            Console.WriteLine("5. Sair");
            Console.WriteLine("Informe a opção: ");
            opcaoMenuBanco = int.Parse(Console.ReadLine());

        }

        //ContaBancaria conta1 = new ContaBancaria()
        //{
        //    Titular = "Gabriel",
        //    Saldo = 1005.95m
        //};
        //conta1.ExibirSaldo();
        //conta1.Sacar(98.14m);
        //conta1.Depositar(33.21m);
        break;

    case 5:
        Aluno aluno1 = new Aluno()
        {
            Nome = "Gabriel",
            Nota = 7.5m
        };

        if (aluno1.EhAprovado())
        {
            Console.WriteLine("Aprovado");
        }
        else
        {
            Console.WriteLine("Reprovado");
        }

        Aluno[] alunos = new Aluno[3];

        for (int i = 0; i < alunos.Length; i++)
        {
            Console.Write("Informe o nome do Aluno para cadastrar: ");
            string nomeCadastro = Console.ReadLine();

            for (int j = 0; j < alunos.Length; j++)
            {
                alunos[i] = new Aluno { Nome = nomeCadastro };
            }
        }

        for (int i = 0; i < alunos.Length; i++)
        {
            Console.WriteLine($"{i + 1}º Aluno: {alunos[i].Nome}");
        }

        break;
}