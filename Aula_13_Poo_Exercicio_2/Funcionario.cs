// Criar classe Pessoa com construtor que recebe Nome e Idade
// Crie a classe funcionario que herda de pessoa
// Adicione a propriedade Cargo
// O construtor de funcionário deve usar base para repassar Nome e Idade
// Crie um objeto Funcionario e exiba nome, idade e cargo

namespace Aula_13_Poo_Exercicio_2
{
    public class Funcionario : Pessoa
    {
        public string Cargo;

        public Funcionario(string nome, int idade, string cargo) : base(nome, idade)
        {
            Cargo = cargo;
        }
    }
}