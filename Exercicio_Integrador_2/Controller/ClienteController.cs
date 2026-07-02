using Exercicio_Integrador_2.Pessoas;
using Exercicio_Integrador_2.Service;

namespace Exercicio_Integrador_2.Controller
{
    public class ClienteController
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteservice)
        {
            _clienteService = clienteservice;
        }

        public void CadastrarCliente()
        {
            Console.WriteLine("=== Cadastrar Cliente ===");
            Console.Write("Nome do Cliente: ");
            string nomeCliente = Console.ReadLine();
            bool ehNomeValido = _clienteService.EhNomeValido(nomeCliente);

            while(!ehNomeValido)
            {
                Console.WriteLine("Informe uma Nome válido!");
                Console.Write("Nome do Cliente: ");
                nomeCliente = Console.ReadLine();
                ehNomeValido = _clienteService.EhNomeValido(nomeCliente);
            }

            Console.Write("Telefone: ");
            string telefoneCliente = Console.ReadLine();

            Console.Write("E-mail: ");
            string emailCliente = Console.ReadLine();

            Console.Write("Tipo do Cliente | C - Padrão | V - VIP | F - FROTAS: ");
            string tipoCliente = Console.ReadLine();
            bool ehTipoClienteValido = _clienteService.TipoClienteEhValido(tipoCliente);

            while (!ehTipoClienteValido)
            {
                Console.WriteLine("Informe um Tipo de Cliente válido!");
                Console.Write("Tipo do Cliente | C - Padrão | V - VIP | F - FROTAS: ");
                tipoCliente = Console.ReadLine();
                ehTipoClienteValido = _clienteService.TipoClienteEhValido(tipoCliente);
            }

            string nomeEmpresa = "";
            int qtdVeiculos = 0;
            string qtdVeiculosString = "";
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

            try
            {
                if (tipoCliente.ToUpper() == "C" || tipoCliente.ToUpper() == "V") // C - Padrão | V - VIP
                {
                    _clienteService.CadastrarCliente(nomeCliente, telefoneCliente, emailCliente, tipoCliente, null, null);
                }
                else // F - Frotas
                {
                    _clienteService.CadastrarCliente(nomeCliente, telefoneCliente, emailCliente, tipoCliente, nomeEmpresa, qtdVeiculosString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
            foreach (Cliente cliente in _clienteService.ListarClientes())
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

            if (_clienteService.ClienteEhCadastrado(nomePesquisaCliente))
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