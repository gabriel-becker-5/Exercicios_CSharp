using Exercicio_Integrador_2.Pessoas;

namespace Exercicio_Integrador_2.Repository
{
    public class ClienteRepository
    {
        public List<Cliente> Clientes = new List<Cliente>
        {
            new Cliente(1, "Gabriel", "47 98888-9999", "gabriel@email.com", DateTime.UtcNow, 0),
            new Cliente(2, "Marcia", "47 98888-9999", "marcia@email.com", DateTime.UtcNow, 0),
            new ClienteFrotista(3, "Paulo", "47 98888-9999", "paulo@email.com", DateTime.UtcNow, 10000, "Paulo Veículos ME", 4),
            new ClienteFrotista(4, "Carlos", "47 98888-9999", "carlos@email.com", DateTime.UtcNow, 50000, "Carlos Veículos ME", 11),
            new ClienteVip(5, "Pedro", "47 98888-9999", "pedro@email.com", DateTime.UtcNow, 1000),
            new ClienteVip(6, "Cássia", "47 98888-9999", "cassia@email.com", DateTime.UtcNow, 1000)
        };

        public List<Funcionario> Funcionarios = new List<Funcionario>
        {
            new Funcionario(7, "Marlon", "47 98888-9999", "marlon@email.com", "Gerente", 15000),
            new Funcionario(8, "Kassio", "47 98888-9999", "kassio@email.com", "Mecânico Sênior", 6500),
            new Funcionario(9, "Alan", "47 98888-9999", "alan@email.com", "Mecânico Júnior", 3000)
        };
    }
}