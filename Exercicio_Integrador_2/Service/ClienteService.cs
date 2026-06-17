using Exercicio_Integrador_2.Pessoas;

namespace Exercicio_Integrador_2.Service
{
    public class ClienteService
    {
        public void CadastrarCliente()
        {
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
        }

        public void ListarClientes()
        {
            Console.WriteLine();
            Console.WriteLine("=== Clientes Cadastrados ===");
            foreach (Cliente cliente in Clientes)
            {
                Console.WriteLine(cliente.ExibirDados());
            }
            Console.WriteLine();
        }

        public void BuscarCliente()
        {
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
        }
    }
}