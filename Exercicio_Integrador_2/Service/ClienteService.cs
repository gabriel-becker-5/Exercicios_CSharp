using Exercicio_Integrador_2.Models;
using Exercicio_Integrador_2.Pessoas;
using Exercicio_Integrador_2.Repository;

namespace Exercicio_Integrador_2.Service
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService(ClienteRepository repository)
        {
            _clienteRepository = repository;
        }

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

            if (tipoCliente.ToUpper() == "C")
            {
                Cliente novoCliente = new Cliente(_clienteRepository.QtdClientesCadastrados()+1, 
                                                  nomeCliente, 
                                                  telefoneCliente, 
                                                  emailCliente, 
                                                  TipoDeCliente.Padrão);
                _clienteRepository.CadastrarCliente(novoCliente);
            }
            else if (tipoCliente.ToUpper() == "V")
            {
                Cliente novoCliente = new Cliente(_clienteRepository.QtdClientesCadastrados()+1, 
                                                  nomeCliente, 
                                                  telefoneCliente, 
                                                  emailCliente, 
                                                  TipoDeCliente.VIP);
                _clienteRepository.CadastrarCliente(novoCliente);
            }
            else
            {
                Cliente novoCliente = new Cliente(_clienteRepository.QtdClientesCadastrados()+1, 
                                                  nomeCliente, 
                                                  telefoneCliente, 
                                                  emailCliente, 
                                                  TipoDeCliente.Frotista, 
                                                  nomeEmpresa, 
                                                  qtdVeiculos);
                _clienteRepository.CadastrarCliente(novoCliente);
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
            foreach (Cliente cliente in _clienteRepository.ListarClientes())
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

            if (_clienteRepository.PesquisarClientePorNome(nomePesquisaCliente))
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