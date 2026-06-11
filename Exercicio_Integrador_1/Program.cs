/* 
Ementa C# Entra 21
- Decisão (IF, ELSE, SWITCH)
- Repetição (FOR, FOREACH, WHILE)
- Objetos (Classes, encapsulamento, herança, abstração, polimorfismo, interface)
- Coleções e LINQ
- Try/Catch/Exceções personalizadas
- Async/Await 

////////////////////////////////////////////////////------------------------///////////////////////////////////////////////////

Exercício Integrador: Sistema de Gestão de Biblioteca Digital
Cenário: Você foi contratado para desenvolver o núcleo de uma biblioteca digital. 

Requisitos
1. Modelagem Orientada a Objetos
Abstração - Crie uma classe abstrata: Pessoa com os campos id e nome e Metodo ObterDescricao().
Herança - Crie duas classes derivadas: Aluno, Professor // Cada uma deve implementar: ObterDescricao() de forma diferente
Interface - Crie a interface: IEmprestavel com métodos emprestar e devolver. Classe Livro herda da IEmprestavel. Implemente os métodos da interface.
Encapsulamento - O livro não deve permitir: Ano < 0. Utilize propriedades com validação.
Polimorfismo - Crie uma list de pessoas e armazene nela alunos e professores. Ao percorrer a lista: execute ObterDescricao() demonstrando polimorfismo.

2. Estruturas de Decisão
Crie um menu principal com Switch e dentro das operações utilize: if / else para validações.
1 - Cadastrar livro, 2 - Cadastrar usuário, 3 - Emprestar livro, 4 - Devolver livro, 5 - Buscar livros, 6 - Relatórios, 0 - Sair

3. Estruturas de Repetição
While - Manter o menu executando até usuário Sair.
Do While - Validar entrada numérica.
For - Exibir relatório numerado.
Foreach - Percorrer coleções.

4. Coleções
Utilize: List<Livro> e List<Pessoa> para armazenar dados. Opcional: Dictionary<int, Livro> para busca rápida.

5. LINQ - Implemente as consultas: 1. Livros disponíveis, 2. Livros por autor, 3. Livros ordenados, 4. Quantidade por autor

6. Exceções - Crie uma exceção personalizada ao emprestar um livro: "LivroIndisponivelException". Trate com: Try, catch, finally.

7. Async/Await - Simule operações de banco de dados.
Crie uma classe: BibliotecaService
Crie os Métodos: Task<List<Livro>> ObterLivrosAsync() e Task SalvarLivroAsync(Livro livro)
Simule demora de 1,5s ao SalvarLivro novo, por exemplo.
 */

using Exercicio_Integrador_1;

int opcaoUsuarioInt = -1;
string opcaoUsuarioString = "";

List<Livro> Livros = new List<Livro>
{
    new Livro (1, "Anakee 1", "Graham II", 1999, true),
    new Livro (2, "Anakee 2", "Graham II", 2000, true),
    new Livro (3, "Anakee 3", "Graham II", 2001, false),
    new Livro (4, "Memórias Póstumas de Brás Cubas", "Machado de Assis", 1881, true),
    new Livro (5, "Quincas Borba", "Machado de Assis", 1891, true),
    new Livro (6, "Dom Casmurro", "Machado de Assis", 1899, true),
    new Livro (7, "Esaú e Jacó", "Machado de Assis", 1904, false),
    new Livro (8, "Ovnis de Campo Largo", "Mayk Leão", 2026, true),
    new Livro (9, "As Sete Leis Espirituais do Sucesso", "Deepak Chopra", 2019, true),
    new Livro (10, "Você é o universo", "Deepak Chopra", 2017, false)
};

List<Pessoa> Pessoas = new List<Pessoa>
{
    new Professor (1, "Gabriel", "Ciência da informação"),
    new Professor (2, "Anderson", "Educação Física"),
    new Aluno (3, "Paulo", "2NC1"),
    new Aluno (4, "Pedro", "2NC2")
};

Livro livro;

while (opcaoUsuarioInt != 0)
{
    Console.WriteLine("=== Seja bem vindo ao sistema da Biblioteca Digital 100% Online ===");
    Console.WriteLine("1. Cadastrar livro");
    Console.WriteLine("2. Cadastrar usuário");
    Console.WriteLine("3. Emprestar livro");
    Console.WriteLine("4. Devolver livro");
    Console.WriteLine("5. Buscar livros");
    Console.WriteLine("6. Relatórios");
    Console.WriteLine("0. Sair");

    do
    {
        Console.Write("Informe a opção: ");
        opcaoUsuarioString = Console.ReadLine();
        Console.WriteLine();
    }
    while (!int.TryParse(opcaoUsuarioString, out opcaoUsuarioInt));

    switch (opcaoUsuarioInt)
    {
        case 1:
            var livroId = Livros.Count() + 1;
            Console.WriteLine("=== Módulo Cadastrar Livro ===");
            bool isDisponivel = false;
            Console.Write("Informe o título do Livro: ");
            string titulo = Console.ReadLine();
            Console.Write("Informe o nome do autor do livro: ");
            string autor = Console.ReadLine();
            Console.Write("Informe o ano de publicação: ");
            int ano;
            bool EhNumero = int.TryParse(Console.ReadLine(), out ano);
            while (!EhNumero)
            {
                Console.WriteLine("Inválido!");
                Console.Write("Informe o ano de publicação: ");
                EhNumero = int.TryParse(Console.ReadLine(), out ano);
            }

            Console.Write("O livro está disponível? (S/N): ");
            var isdisponivelText = Console.ReadLine(); 

            while (isdisponivelText.ToUpper() != "S" && isdisponivelText.ToUpper() != "N")
            {
                Console.WriteLine("Inválido!");
                Console.Write("O livro está disponível? (S/N): ");
                isdisponivelText = Console.ReadLine();
            }

            if (isdisponivelText.ToUpper() == "S")
            {
                isDisponivel = true;
            }
            else
            {
                isDisponivel = false;
            }

            try
            {
                BibliotecaService service = new BibliotecaService();
                Livro novoLivro = new Livro(livroId, titulo, autor, ano, isDisponivel);
                await service.SalvarLivroAsync(novoLivro, Livros);
                Console.WriteLine("Livro cadastrado com sucesso.");
                Console.WriteLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                Console.WriteLine();
            }

            livroId = 0;
            titulo = "";
            autor = "";
            ano = 0;
            isDisponivel = false;

            break;

        case 2:
            var usuarioId = Pessoas.Count() + 1;
            Console.WriteLine("=== Módulo Cadastrar Usuário ===");
            Console.Write("Informe o nome do Usuário: ");
            string nomeUsuario = Console.ReadLine();

            Console.Write("Informe o tipo do Usuário (P - Professor  | A - Aluno): ");
            string tipoUsuario = Console.ReadLine();

            while (tipoUsuario.ToUpper() != "P" && tipoUsuario.ToUpper() != "A")
            {
                Console.WriteLine("Inválido!");
                Console.Write("Informe o tipo do Usuário (P - Professor  | A - Aluno): ");
                tipoUsuario = Console.ReadLine();
            }

            if (tipoUsuario.ToUpper() == "P")
            {
                Console.Write("Informe a Matéria que leciona: ");
                string materia = Console.ReadLine();
                Pessoa novoUsuario = new Professor(usuarioId, nomeUsuario, materia);
                Pessoas.Add(novoUsuario);
                Console.WriteLine($"Usuário cadastrado com sucesso. Detalhes: {novoUsuario.ObterDescricao()}");
            }
            else
            {
                Console.Write("Informe a Turma do Aluno: ");
                string turma = Console.ReadLine();
                Pessoa novoUsuario = new Aluno(usuarioId, nomeUsuario, turma);
                Pessoas.Add(novoUsuario);
                Console.WriteLine($"Usuário cadastrado com sucesso. Detalhes: {novoUsuario.ObterDescricao()}");
            }
            break;

        case 3:
            Console.WriteLine("=== Módulo Emprestar Livro ===");
            Console.Write("Informe o ID do Livro: ");
            int idLivro = int.Parse(Console.ReadLine());

            Console.Write("Informe o ID do Aluno: ");
            int idAluno = int.Parse(Console.ReadLine());

            Console.Write("Dias de empréstimo: ");
            int diasEmprestimo = int.Parse(Console.ReadLine());
            try
            {
                livro = Livros.First(l => l.Id == idLivro);
                livro.Emprestar(idLivro, idAluno, diasEmprestimo);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Livro não cadastrado na base.");
            }
            catch (LivroIndisponivelException ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;

        case 4:
            Console.WriteLine("=== Módulo Devolver Livro ===");
            Console.Write("Informe o ID do Livro: ");
            idLivro = int.Parse(Console.ReadLine());
            try
            {
                livro = Livros.First(l => l.Id == idLivro);
                livro.Devolver(idLivro);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Livro não cadastrado na base.");
            }
            catch (LivroIndisponivelException ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;

        case 5:
            Console.WriteLine("=== Módulo Buscar Livro ===");
            Console.Write("Informe o ID do Livro: ");
            idLivro = int.Parse(Console.ReadLine());
            livro = Livros.First(l => l.Id == idLivro);
            livro.DetalharCadastroLivro();
            break;

        case 6:
            Console.WriteLine("=== Módulo Relatórios ===");
            Console.WriteLine("1. Livros disponíveis");
            Console.WriteLine("2. Livros por autor");
            Console.WriteLine("3. Livros ordenados");
            Console.WriteLine("4. Quantidade Livros por Autor");
            Console.WriteLine("5. Listar Usuários do Sistema");
            Console.WriteLine("6. Exibir Livros cadastrados (Com Query)");
            Console.WriteLine("7. Retornar ao menu anterior");

            string opcaoUsuarioRelatorio;
            int opcaoUsuarioRelatorioInt;

            do
            {
                Console.Write("Informe a opção: ");
                opcaoUsuarioRelatorio = Console.ReadLine();
                Console.WriteLine();
            }
            while (!int.TryParse(opcaoUsuarioRelatorio, out opcaoUsuarioRelatorioInt));

            switch (opcaoUsuarioRelatorioInt)
            {
                case 1:
                    Console.WriteLine("=== RELATÓRIO LIVROS DISPONÍVEIS ===");
                    foreach (Livro livroUnitario in Livros
                        .Where(l => l.IsDisponivel == true))
                    {
                        livroUnitario.DetalharCadastroLivro();
                    }
                    Console.WriteLine();
                    break;

                case 2:
                    Console.WriteLine("=== RELATÓRIO LIVROS POR AUTOR ===");
                    foreach (var livroUnitario in Livros
                        .GroupBy(l => l.Autor)
                        .Select(g => new
                        {
                            Autor = g.Key,
                            Livros = string.Join(", ", g.Select(l => l.Titulo))
                        })
                        .OrderBy(l => l.Autor))
                    {
                        Console.WriteLine("Autor: " + livroUnitario.Autor + " - Livros: " + livroUnitario.Livros);
                    }
                    Console.WriteLine();                   
                    break;

                case 3:
                    Console.WriteLine("=== RELATÓRIO LIVROS ORDENADOS (A - Z) ===");
                    foreach (var livrosOrdemAlfabetica in Livros
                        .OrderBy(l => l.Titulo))
                    {
                        livrosOrdemAlfabetica.DetalharCadastroLivro();
                    }
                    Console.WriteLine();
                    break;

                case 4:
                    Console.WriteLine("=== RELATÓRIO QUANTIDADE LIVROS POR AUTOR ===");
                    foreach (var _autor in Livros
                        .GroupBy(l => l.Autor)
                        .Select(livrosAgrupadosPorAutor => new
                        {
                            Chave = livrosAgrupadosPorAutor.Key,
                            Quantidade = livrosAgrupadosPorAutor.Count()
                        })
                        .OrderByDescending(l => l.Quantidade))
                    {
                        Console.WriteLine("Autor: " + _autor.Chave + " - Livros: " + _autor.Quantidade);
                    }
                    Console.WriteLine();
                    break;

                case 5:
                    Console.WriteLine("=== RELATÓRIO DE USUÁRIOS ===");

                    foreach (Pessoa pessoa in Pessoas)
                    {
                        Console.WriteLine(pessoa.ObterDescricao());
                    }
                    break;

                case 6:
                    Console.WriteLine("=== RELATÓRIO DE LIVROS (COM QUERY DB) ===");
                    BibliotecaService service = new BibliotecaService();

                    var livros = await service.ObterLivrosAsync(Livros);

                    foreach (var livrounit in livros)
                    {
                        livrounit.DetalharCadastroLivro();
                    }
                    Console.WriteLine();
                    break;
            }
            break;
    }
}