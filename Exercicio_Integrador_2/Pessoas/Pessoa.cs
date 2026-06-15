/* Classe Abstrata Pessoa -  Representa qualquer pessoa cadastrada no sistema.
Atributos: Id, Nome, Telefone, Email
Métodos: ExibirDados() */

namespace Exercicio_Integrador_2.Pessoas
{
    public abstract class Pessoa
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }

        public Pessoa(int id, string nome, string telefone, string email)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;
        }

        public virtual string ExibirDados()
        {
            return $"ID: {Id} | Nome: {Nome} | Telefone: {Telefone} | E-mail: {Email} | Tipo de Cliente: {GetType().Name}";
        }
    }
}