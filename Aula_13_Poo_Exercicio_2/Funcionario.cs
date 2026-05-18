namespace Aula_13_Poo_Exercicio_2
{
    public class Funcionario : Pessoa
    {
        public string Cargo { get; private set; }

        public Funcionario(string nome, int idade, string cargo) : base(nome, idade)
        {
            Cargo = cargo;
        }

        public void ExibirCadastro()
        {
            Console.WriteLine($"Nome: {Nome}. Idade: {Idade}. Cargo: {Cargo}.");
        }
    }
}