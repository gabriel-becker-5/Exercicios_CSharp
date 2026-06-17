/* Exercício 1 - Estrutura o projeto e o modelo Produto
Crie um novo projeto console: CatalogoProdutos. 
Crie as pastas: Modelos, Interfaces, Repositorios, Excecoes e Servicos.
Em Modelos/Produto.cs crie a classe Produto com: int Id, string Nome, string Categoria, decimal Preco.
Em Program.cs crie 5 produtos de categorias diferentes e exiba-os com foreach.

Exercício 2 - Interface + Repositório com LINQ
Crie IRepositorioProduto com:
void Adicionar(Produto p), List<Produto> ListarTodos() e List<Produto> BuscarPorCategoria(string categoria)
Implemente RepositorioProduto usando List<Produto> internamente. Use LINQ (where) em BuscarPorCategoria. 
No Main, popule o repositório e teste a busca por categoria.

Exercício 3 - Exceção customizada + validação
Crie ProdutoNaoEncontradoException : Exception com mensagem "Produto {id} não encontrado.".
Adicione à interface: Produto BuscarPorId(int id). Implemente lançando a exceção customizada via FirstOrDefault + operador ?? throw.
No Main, teste com um Id existente e um inexistente, tratando com try/catch.

Exercício 4 - Instalar e usar um pacote NuGet
Instale o pacote ConsoleTables: dotnet add package ConsoleTables.
Crie um método ExibirTabela(List<Produto> produtos) que:
- Cria uma ConsoleTable com colunas Id, Nome, Categoria, Preço.
- Adiciona uma linha (AddRow) para cada produto e Chama table.Write() para exibir no console.
Use LINQ para exibir a tabela ordenada por Preço (OrderBy).

Exercício 5 - Serviço Assíncrono com HttpClient
Crie Servicos/CotacaoService.cs com o método: async Task<decimal> ObterCotacaoDolarAsync()
Use HttpClient para buscar: "https://economia.awesomeapi.com.br/json/last/USD-BRL"
Use Newtonsoft.json (Jsonconvert.DeserializeObject<dynamic>) para extrair o campo 'bid' como decimal.
No Main, busque a cotação com await e exiba: "Cotação do Dólar: R$ {cotacaoDolar}. Trate erros com try/catch.

Exercício Extra - Catálogo de Produtos completo - integração final
Junte tudo dos exercícios anteriores em um programa único com menu interativo. O menu deve oferecer:
1. Listar todos os produtos (ConsoleTable, ordenados por preço)
2. Buscar produto por categoria (LINQ Where)
3. Buscar produto por Id (com tratamento de exceção customizada)
4. Ver preços convertidos em dólar (busca cotação via HttpClient + async)
5. Salvar catálogo em catalogo.json (Newtonsoft.json)
0. Sair
Use Loop while + switch para o menu, repetindo até o usuário decidir sair. */

using Aula_19_Exercicios.Excecoes;
using Aula_19_Exercicios.Modelos;
using Aula_19_Exercicios.Repositorios;
using Newtonsoft.Json;

RepositorioProduto repositorio = new RepositorioProduto();
int opcaoMenuInt = -1;
string opcaoMenuString;
bool ehOpcaoMenuValida;

Console.WriteLine("===== Bem-vindo Usuário =====");

while (opcaoMenuInt != 0)
{
    Console.WriteLine("===== Menu de Opções =====");
    Console.WriteLine("1. Listar todos os produtos (console table, ordenados por preço)");
    Console.WriteLine("2. Buscar produto por categoria (LINQ where)");
    Console.WriteLine("3. Buscar produto por Id (com tratamento de exceção customizada)");
    Console.WriteLine("4. Ver os preços convertidos em dólar (busca cotação via HttpClient + async)");
    Console.WriteLine("5. Salvar catálogo em catalogo.json (Newtonsoft.json)");
    Console.WriteLine("6. Cadastrar Novo Produto");
    Console.WriteLine("0. Sair");
    Console.Write("Informe a Opção: ");
    opcaoMenuString = Console.ReadLine();
    ehOpcaoMenuValida = int.TryParse(opcaoMenuString, out opcaoMenuInt);

    while (!ehOpcaoMenuValida)
    {
        Console.WriteLine("Opção inválida, tente novamente.");
        Console.Write("Informe a Opção: ");
        opcaoMenuString = Console.ReadLine();
        ehOpcaoMenuValida = int.TryParse(opcaoMenuString, out opcaoMenuInt);
    }

    Console.WriteLine();

    switch (opcaoMenuInt)
    {
        case 1:
            // 1. Listar todos os produtos (ConsoleTable, ordenados por preço)
            
            Console.WriteLine("===== Relatório: Produtos Cadastrados =====");
            repositorio.ExibirTabela();
            Console.WriteLine();
            break;

        case 2:
            // 2. Buscar produto por categoria (LINQ Where)
            Console.WriteLine("===== Pesquisar Produto por Categoria =====");
            Console.Write("Categoria: ");
            string categoriaPesquisa = Console.ReadLine();
            List<Produto> produtosEncontrados = repositorio.BuscarPorCategoria(categoriaPesquisa);

            if (produtosEncontrados.Count() == 0)
            {
                Console.WriteLine("Não há produtos cadastrados na Categoria.");
            }
            else
            {
                foreach (Produto produto in produtosEncontrados)
                {
                    Console.WriteLine();
                    Console.WriteLine($"===== Produtos Categoria: {categoriaPesquisa.ToUpper()} =====");
                    Console.WriteLine($"ID: {produto.Id} | Descrição: {produto.Nome} | Categoria: {produto.Categoria} | Preço: {produto.Preco:C2}");
                }
            }
            Console.WriteLine();
            break;

        case 3:
            // 3. Buscar produto por Id (com tratamento de exceção customizada)
            Console.WriteLine("===== Pesquisar Produto por ID =====");
            Console.Write("Informe o ID do Produto: ");
            int idDoProdutoInt;
            string idDoProdutoString = Console.ReadLine();
            bool ehIdDoProdutoValida = int.TryParse(idDoProdutoString, out idDoProdutoInt);

            while (!ehIdDoProdutoValida)
            {
                Console.WriteLine("Produto informado inválido.");
                Console.Write("Informe o ID do Produto: ");
                idDoProdutoString = Console.ReadLine();
                ehIdDoProdutoValida = int.TryParse(idDoProdutoString, out idDoProdutoInt);
            }

            try
            {
                Produto produtoPesquisado = repositorio.BuscarPorId(idDoProdutoInt);
                Console.WriteLine($"ID: {produtoPesquisado.Id} | Nome: {produtoPesquisado.Nome} | Categoria: {produtoPesquisado.Categoria} | Preço: {produtoPesquisado.Preco:C2}");
            }
            catch (ProdutoNaoEncontradoException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            break;

        case 4:
            // 4. Ver preços convertidos em dólar (busca cotação via HttpClient + async)
            repositorio.ExibirTabelaEmDolar();
            Console.WriteLine();
            break;

        case 5:
            // 5. Salvar catálogo em catalogo.json (Newtonsoft.json)
            File.Delete("catalogo.json");
            List<Produto> listaDeProdutos = repositorio.ListarTodos();
            var listaDeProdutosJSON = JsonConvert.SerializeObject(listaDeProdutos, Formatting.Indented);
            File.WriteAllText("catalogo.json", listaDeProdutosJSON);
            Console.WriteLine("===============================================");
            Console.WriteLine("Catálogo de Produtos exportado com sucesso.");
            Console.WriteLine("===============================================");
            Console.WriteLine();
            break;

        case 6:
            // 6. Cadastrar Novo Produto
            Console.WriteLine("===== Cadastrar Novo Produto =====");
            Console.Write("Descrição: ");
            string descricaoProduto = Console.ReadLine();
            Console.Write("Categoria: ");
            string categoriaProduto = Console.ReadLine();

            Console.Write("Preço: ");
            decimal precoProdutoDecimal;
            string precoProdutoString = Console.ReadLine();
            bool ehPrecoValido = decimal.TryParse(precoProdutoString, out precoProdutoDecimal);

            while (!ehPrecoValido || precoProdutoDecimal <= 0)
            {
                Console.WriteLine("Preço informado inválido.");
                Console.Write("Preço: ");
                precoProdutoString = Console.ReadLine();
                ehPrecoValido = decimal.TryParse(precoProdutoString, out precoProdutoDecimal);
            }

            Produto novoProduto = new Produto(descricaoProduto, categoriaProduto, precoProdutoDecimal);
            repositorio.Adicionar(novoProduto);
            Console.WriteLine();
            break;

        default:
            break;
    }
}