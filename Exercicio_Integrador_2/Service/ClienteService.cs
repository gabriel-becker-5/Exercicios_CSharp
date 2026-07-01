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

        public void CadastrarCliente(string nome, 
                                     string telefone, 
                                     string email, 
                                     string tipocliente, 
                                     string? nomeempresa, 
                                     string? qtdveiculos)
        {
            Cliente novoCliente;

            if (tipocliente.ToUpper() == "C")
            {
                novoCliente = new Cliente(_clienteRepository.QtdClientesCadastrados() + 1,
                                                  nome,
                                                  telefone,
                                                  email,
                                                  TipoDeCliente.Padrão);
            }
            else if (tipocliente.ToUpper() == "V")
            {
                novoCliente = new Cliente(_clienteRepository.QtdClientesCadastrados() + 1,
                                                  nome,
                                                  telefone,
                                                  email,
                                                  TipoDeCliente.VIP);
            }
            else
            {
                int qtdVeiculosInt;
                bool ehNumeroValido = int.TryParse(qtdveiculos, out qtdVeiculosInt);

                novoCliente = new Cliente(_clienteRepository.QtdClientesCadastrados() + 1,
                                                  nome,
                                                  telefone,
                                                  email,
                                                  TipoDeCliente.Frotista,
                                                  nomeempresa,
                                                  qtdVeiculosInt);
            }
            _clienteRepository.CadastrarCliente(novoCliente);
        }

        public List<Cliente> ListarClientes()
        {
            return _clienteRepository.ListarClientes();
        }

        public bool ClienteEhCadastrado(string nome)
        {
            return _clienteRepository.PesquisarClientePorNome(nome);
        }
    }
}