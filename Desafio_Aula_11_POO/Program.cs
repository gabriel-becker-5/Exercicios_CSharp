// DESAFIO AULA 11 POO
// OBJETIVO: SIMULAÇÃO REAL
// ENUNCIADO: CRIE UM SISTEMA DE ALUNOS
// 1. CADASTRAR ALUNOS -- check
// 2. LISTAR ALUNOS
// 3. MOSTRAR MÉDIA DA TURMA
// 4. MOSTRAR QUANTOS FORAM APROVADOS

using Desafio_Aula_11_POO;
int opcaoMenu = 0;
int maxAlunosPermitidos = 10;
int qtdAlunosMatriculados = 0;
decimal notaAluno;
Aluno[] alunos = new Aluno[maxAlunosPermitidos];
int opcaoSair = 6;

Console.WriteLine("=====  Bem vindo ao sistema de gestão de Alunos  =====");
Console.WriteLine("");
while (opcaoMenu != opcaoSair)
{
    Console.WriteLine("=====  MENU =====");
    Console.WriteLine("1. Cadastrar Novo Aluno");
    Console.WriteLine("2. Listar Alunos Matriculados");
    Console.WriteLine("3. Exibir Média da Turma");
    Console.WriteLine("4. Exibir Qtd. Alunos Aprovados");
    Console.WriteLine("5. Exibir Boletins");
    Console.WriteLine("6. Sair");
    Console.Write("-> Informe a opção: ");
    int.TryParse(Console.ReadLine(), out opcaoMenu);

    switch (opcaoMenu)
    {
        case 1:
            Console.WriteLine("");
            Console.WriteLine("=== MÓDULO DE MATRÍCULAS ===");
            if (qtdAlunosMatriculados < maxAlunosPermitidos)
            {
                Console.Write("Informe o nome do aluno para cadastrar: ");
                string nomeAluno = Console.ReadLine();

                bool notaValida;

                do
                {
                    Console.Write("Informe a nota: ");
                    notaValida = decimal.TryParse(Console.ReadLine(), out notaAluno);

                    while (!notaValida)
                    {
                        Console.WriteLine("Informe uma nota válida!");
                        Console.Write("Informe a nota: ");
                        notaValida = decimal.TryParse(Console.ReadLine(), out notaAluno);
                    }

                    if (notaAluno < 0)
                    {
                        Console.WriteLine("A nota precisa ser 0 ou maior.");
                    }

                } while (notaAluno < 0);


                for (int i = 0; i < alunos.Length; i++)
                {
                    if (alunos[i] == null)
                    {
                        alunos[i] = new Aluno(nomeAluno, notaAluno);
                        qtdAlunosMatriculados++;
                        Console.WriteLine("Aluno matriculado com sucesso.");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Não há mais vagas disponíveis!");
            }
            Console.WriteLine("");
            break;

        case 2:
            Console.WriteLine("");
            Console.WriteLine("=== RELATÓRIO DE ALUNOS MATRICULADOS ===");
            bool possuiAlunos = false;

            for (int i = 0; i < alunos.Length; i++)
            {
                if (alunos[i] != null)
                {
                    possuiAlunos = true;
                    Console.Write($"{i + 1}. ");
                    alunos[i].Apresentacao();
                }
            }
            if (!possuiAlunos)
            {
                Console.WriteLine("Não há alunos matriculados!");
            }
            Console.WriteLine("");
            break;

        case 3:
            decimal somatorioNotas = 0;
            decimal mediaTurma = 0;
            for (int i = 0; i < alunos.Length; i++)
            {
                if (alunos[i] != null)
                {
                    somatorioNotas += alunos[i].Nota;
                }
            }

            if (somatorioNotas > 0)
            {
                mediaTurma = somatorioNotas / qtdAlunosMatriculados;
            }
            else
            {
                mediaTurma = 0;
            }

            Console.WriteLine("");
            Console.WriteLine("=======================================");
            Console.WriteLine($"MÉDIA DA TURMA: {mediaTurma}");
            Console.WriteLine("=======================================");
            Console.WriteLine("");
            break;

        case 4:
            int qtdAlunosAprovados = 0;
            for (int i = 0; i < alunos.Length; i++)
            {
                if (alunos[i] != null && alunos[i].EhAprovado())
                {
                    qtdAlunosAprovados++;
                }
            }

            decimal percentual = 0;
            if (qtdAlunosMatriculados > 0)
            {
                percentual = (decimal)qtdAlunosAprovados / qtdAlunosMatriculados * 100;
            }

            Console.WriteLine("");
            Console.WriteLine("=======================================");
            Console.WriteLine($"ALUNOS APROVADOS: {qtdAlunosAprovados}");
            Console.WriteLine($"ALUNOS MATRICULADOS: {qtdAlunosMatriculados}");
            Console.WriteLine($"% APROVAÇÃO: {percentual}");
            Console.WriteLine("=======================================");
            Console.WriteLine("");
            break;

        case 5:
            Console.WriteLine("");
            Console.WriteLine("=== BOLETINS ===");
            Console.WriteLine("Nome do Aluno  |  Nota  |  Situação");
            for (int i = 0; i < alunos.Length; i++)
            {
                if (alunos[i] != null)
                {
                    Console.Write($"{i + 1}. ");
                    alunos[i].ApresentacaoCompleta();
                }
                else
                {
                    if (qtdAlunosMatriculados == 0)
                    {
                        Console.WriteLine("Não há alunos matriculados!");

                    }
                    break;
                }
            }
            Console.WriteLine("");
            break;

        default:
            Console.WriteLine("Opção inválida.");
            Console.WriteLine("");
            break;
    }
}