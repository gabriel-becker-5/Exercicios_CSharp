/* Classe Funcionario - Herda de Pessoa.
Atributos: Cargo, Salario
Métodos: ExibirDados() */

namespace Exercicio_Integrador_2.Pessoas
{
    public class Funcionario : Pessoa
    {
        public string Cargo { get; private set; }
        public decimal Salario { get; private set; }
        public Funcionario(int id, string nome, string telefone, string email, string cargo, decimal salario) : base(id, nome, telefone, email)
        {
            Cargo = cargo;
            Salario  = salario;
        }

        public override string ExibirDados()
        {
            return $"{base.ExibirDados()} | Cargo: {Cargo} | Salário: {Salario:C2}";
        }
    }
}