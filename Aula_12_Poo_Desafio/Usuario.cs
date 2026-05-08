// Crie um sistema de cadastro de usuários.
// Cada usuário deve possuir: Nome, Idade, Email
// Regras:
// 1. Idade não pode ser negativa
// 2. E-mail não pode ser vazio
// 3. Todos os atributos devem ser privados
// 4. Utilizar getters/setters ou properties
// 5. Exibir dados cadastrados ao final

namespace Aula_12_Poo_Desafio
{
    internal class Usuario
    {
        private string nome;
        private int idade;
        private string email;

        public string Nome
        {
            get { return nome; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    nome = value;
                }
            }
        }

        public int Idade
        {
            get { return idade; }
            set
            {
                if (value >= 0)
                {
                    idade = value;
                }
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    email = value;
                }
            }
        }

        public void ExibirCadastro()
        {
            Console.WriteLine($"Nome: {Nome}  |  E-mail: {Email}  |  Idade: {Idade}.");
        }
    }
}