// crie um programa que: tenha um array para armazenar até 5 nomes
// regras: não permitir ultrapassar o limite do array, informar se o nome já existe, informar se não encontrar na busca
// desafio adicional: função excluir nome cadastrado

int qtdNomesPermitidos = 5;
string[] nomesCadastrados = new string[qtdNomesPermitidos];
string nomeParaCadastrar;
int quantidadeNomesCadastrados = 0;
string confirmaNomeCadastro;
string inputDoUsuario;
int opcaoMenuSelecionada;
bool isOpcaoSelecionadaValida;
int opcaoFinalDoMenu = 5;
int opcaoInicialDoMenu = 1;

Console.WriteLine("========================================================");
Console.WriteLine("Olá querido usuário(a), selecione uma das opções");
Console.WriteLine("========================================================");
Console.WriteLine("");
Console.WriteLine("1) Cadastrar Nome");
Console.WriteLine("2) Listar Nomes Cadastrados");
Console.WriteLine("3) Pesquisar Nomes Cadastrados");
Console.WriteLine("4) Excluir Nome Cadastrado");
Console.WriteLine("5) Encerrar");
Console.WriteLine("");
Console.WriteLine("========================================================");
Console.Write("Opção selecionada: ");
inputDoUsuario = Console.ReadLine();
Console.WriteLine("");

isOpcaoSelecionadaValida = int.TryParse(inputDoUsuario, out opcaoMenuSelecionada);

while (!isOpcaoSelecionadaValida || opcaoMenuSelecionada < opcaoInicialDoMenu || opcaoMenuSelecionada > opcaoFinalDoMenu)
{
    Console.Write("Opção inválida! Tente novamente: ");
    inputDoUsuario = Console.ReadLine();
    isOpcaoSelecionadaValida = int.TryParse(inputDoUsuario, out opcaoMenuSelecionada);
}

while (opcaoMenuSelecionada != opcaoFinalDoMenu)
{
    switch (opcaoMenuSelecionada)
    {
        case 1:
            // Adicionar nome
            Console.Write("Digite o nome para cadastrar: ");
            nomeParaCadastrar = Console.ReadLine();

            Console.Write($"Confirma o nome '{nomeParaCadastrar}'? (Y/N): ");
            confirmaNomeCadastro = Console.ReadLine();

            // Só prossegue se o usuário confirmar com "Y"
            while (confirmaNomeCadastro.ToUpper() != "Y")
            {
                Console.Write("Digite o nome para cadastrar: ");
                nomeParaCadastrar = Console.ReadLine();

                Console.Write($"Confirma o nome '{nomeParaCadastrar}'? (Y/N): ");
                confirmaNomeCadastro = Console.ReadLine();
            }

            // Conta os nomes cadastrados e Verifica se o Nome já existe no array
            quantidadeNomesCadastrados = 0;
            bool isNomeJaCadastrado = false;

            for (int i = 0; i < qtdNomesPermitidos; i++)
            {
                if (!string.IsNullOrWhiteSpace(nomesCadastrados[i]))
                {
                    quantidadeNomesCadastrados++;
                }

                if (nomeParaCadastrar == nomesCadastrados[i])
                {
                    isNomeJaCadastrado = true;
                }
            }

            // Se nome for duplicado retornar ao menu inicial
            if (isNomeJaCadastrado)
            {
                Console.WriteLine($"Ação não permitida! Nome '{nomeParaCadastrar}' já cadastrado na Agenda.");
                break;
            }

            // Se não houver espaço no array retorna ao menu inicial
            if (quantidadeNomesCadastrados == qtdNomesPermitidos)
            {
                Console.WriteLine("Agenda cheia! Exclua um nome antes de poder cadastrar um novo.");
                break;
            }

            // Grava o nome na última posição disponível no array
            for (int i = 0; i < qtdNomesPermitidos; i++)
            {
                if (string.IsNullOrWhiteSpace(nomesCadastrados[i]))
                {
                    nomesCadastrados[i] = nomeParaCadastrar;
                    Console.WriteLine($"Nome: '{nomeParaCadastrar}' cadastrado com sucesso.");
                    break;
                }
            }
            break;

        case 2:
            // Listar nomes
            quantidadeNomesCadastrados = 0;

            for (int i = 0; i < qtdNomesPermitidos; i++)
            {
                if (!string.IsNullOrWhiteSpace(nomesCadastrados[i]))
                {
                    quantidadeNomesCadastrados++;
                }
            }

            Console.WriteLine("Nomes cadastrados: ");

            for (int i = 0; i < quantidadeNomesCadastrados; i++)
            {
                Console.WriteLine($"{i + 1}. {nomesCadastrados[i]}");
            }
            break;

        case 3:
            // Buscar nome
            string nomeParaPesquisar;
            Console.Write("Digite um nome para pesquisar na base de dados: ");
            nomeParaPesquisar = Console.ReadLine();
            bool nomeEncontrado = false;
            quantidadeNomesCadastrados = 0;

            for (int i = 0; i < qtdNomesPermitidos; i++)
            {
                if (!string.IsNullOrWhiteSpace(nomesCadastrados[i]))
                {
                    quantidadeNomesCadastrados++;
                }
            }

            for (int i = 0; i < quantidadeNomesCadastrados; i++)
            {
                if (nomesCadastrados[i].ToUpper() == nomeParaPesquisar.ToUpper())
                {
                    nomeEncontrado = true;
                }
            }

            if (nomeEncontrado)
            {
                Console.WriteLine("Nome cadastrado na base de dados!");
            }
            else
            {
                Console.WriteLine("Nome não cadastrado na base");
            }
            break;

        case 4:
            // Excluir nome cadastrado
            Console.Write("Digite um nome para excluir da base de dados: ");
            nomeParaPesquisar = Console.ReadLine();
            nomeEncontrado = false;

            for (int i = 0; i <= quantidadeNomesCadastrados; i++)
            {
                if (nomesCadastrados[i].ToUpper() == nomeParaPesquisar.ToUpper())
                {
                    nomeEncontrado = true;
                    nomesCadastrados[i] = null;
                    break;
                }
            }

            // reorganiza o indice
            if (nomeEncontrado)
            {
                for (int i = 0; i <= quantidadeNomesCadastrados; i++)
                {
                    if (nomesCadastrados[i] == null && i == (quantidadeNomesCadastrados - 1))
                    {
                        break;
                    }
                    else if (nomesCadastrados[i] == null)
                    {
                        nomesCadastrados[i] = nomesCadastrados[i + 1];
                        nomesCadastrados[i + 1] = null;
                    }
                }

                Console.WriteLine("Nome excluído da base de dados!");
                quantidadeNomesCadastrados--;
            }
            else
            {
                Console.WriteLine("Nome não encontrado na base de dados.");
            }
            break;

        default:
            break;
    }

    Console.WriteLine("========================================================");
    Console.WriteLine("");
    Console.WriteLine("1) Cadastrar Nome");
    Console.WriteLine("2) Listar Nomes Cadastrados");
    Console.WriteLine("3) Pesquisar Nomes Cadastrados");
    Console.WriteLine("4) Excluir Nome Cadastrado");
    Console.WriteLine("5) Encerrar");
    Console.WriteLine("");
    Console.WriteLine("========================================================");
    Console.Write("Opção selecionada: ");
    inputDoUsuario = Console.ReadLine();
    Console.WriteLine("");

    isOpcaoSelecionadaValida = int.TryParse(inputDoUsuario, out opcaoMenuSelecionada);

    while (!isOpcaoSelecionadaValida || opcaoMenuSelecionada < opcaoInicialDoMenu || opcaoMenuSelecionada > opcaoFinalDoMenu)
    {
        Console.Write("Opção inválida! Tente novamente: ");
        inputDoUsuario = Console.ReadLine();
        isOpcaoSelecionadaValida = int.TryParse(inputDoUsuario, out opcaoMenuSelecionada);
    }
}