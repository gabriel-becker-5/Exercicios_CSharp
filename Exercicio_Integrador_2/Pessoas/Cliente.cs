/* Classe Cliente - Herda de Pessoa.
Atributos: DataCadastro, TotalGasto
Métodos: AtualizarTotalGasto() */

namespace Exercicio_Integrador_2.Pessoas
{
    public class Cliente : Pessoa
    {
        public DateTime DataCadastro { get; private set; }
        public decimal TotalGasto {  get; private set; }

        public Cliente(int id, string nome, string telefone, string email, DateTime datacadastro, decimal totalgasto) : base(id, nome, telefone, email)
        {
            DataCadastro = DateTime.UtcNow;
            TotalGasto = 0;
        }

        public virtual string ExibirDados()
        {
            return $"ID: {Id} | Nome: {Nome} | Telefone: {Telefone} | E-mail: {Email}";
        }

        public void AtualizarTotalGasto() // PENDENTE, FALTA OS OBJETOS NECESSÁRIOS
        {

        }
    }
}