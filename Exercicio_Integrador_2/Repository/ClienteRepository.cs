using Exercicio_Integrador_2.Models;
using Exercicio_Integrador_2.Pessoas;

namespace Exercicio_Integrador_2.Repository
{
    public class ClienteRepository
    {
        public List<Cliente> Clientes = new List<Cliente>
            {
                new Cliente(1, "Gabriel", "47 98888-9999", "gabriel@email.com", TipoDeCliente.Padrão),
                new Cliente(2, "Marcia", "47 98888-9999", "marcia@email.com", TipoDeCliente.Padrão),
                new Cliente(3, "Paulo", "47 98888-9999", "paulo@email.com", TipoDeCliente.Frotista, "Paulo Veículos ME", 4),
                new Cliente(4, "Carlos", "47 98888-9999", "carlos@email.com", TipoDeCliente.Frotista, "Carlos Veículos ME", 11),
                new Cliente(5, "Pedro", "47 98888-9999", "pedro@email.com", TipoDeCliente.VIP),
                new Cliente(6, "Cássia", "47 98888-9999", "cassia@email.com", TipoDeCliente.VIP)
            };

        public int QtdClientesCadastrados()
        {
            return Clientes.Count();
        }

        public void CadastrarCliente(Cliente cliente)
        {
            Clientes.Add(cliente);
        }

        public List<Cliente> ListarClientes()
        {
            return Clientes;
        }

        public bool PesquisarClientePorNome(string nome)
        {
            int qtdClientesCadastrados = Clientes.Count(c => c.Nome.ToUpper() == nome.ToUpper());

            if (qtdClientesCadastrados == 0)
            {
                return false;
            }
            return true;
        }

        public Cliente PesquisarClientePorID(int id)
        {
            return Clientes.FirstOrDefault(c => c.Id == id);
        }
    }
}