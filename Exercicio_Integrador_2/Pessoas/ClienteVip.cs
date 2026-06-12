/* Classe ClienteVip - Herda de Cliente.
Regras: Possui desconto especial em serviços. */

namespace Exercicio_Integrador_2.Pessoas
{
    public class ClienteVip : Cliente
    {
        public const decimal DESCONTO_EXTRA = 0.05m;

        public ClienteVip(int id, string nome, string telefone, string email, DateTime datacadastro, decimal totalgasto) : 
            base(id, nome, telefone, email, datacadastro, totalgasto)
        {
        }
        public virtual string ExibirDados()
        {
            return $"ID: {Id} | Nome: {Nome} | Telefone: {Telefone} | E-mail: {Email}";
        }
    }
}