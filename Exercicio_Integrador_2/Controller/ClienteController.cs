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
            _clienteService.CadastrarCliente();
        }

        public void ListarClientes()
        {
            _clienteService.ListarClientes();
        }

        public void BuscarCliente()
        {
            _clienteService.BuscarCliente();
        }
    }
}