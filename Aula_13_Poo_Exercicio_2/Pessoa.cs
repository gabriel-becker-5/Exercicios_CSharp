// Criar classe Pessoa com construtor que recebe Nome e Idade
// Crie a classe funcionario que herda de pessoa
// Adicione a propriedade Cargo
// O construtor de funcionário deve usar base para repassar Nome e Idade
// Crie um objeto Funcionario e exiba nome, idade e cargo

namespace Aula_13_Poo_Exercicio_2
{
    public class Pessoa
    {
        public string Nome;
        public int Idade;

        public Pessoa(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }
    }
}