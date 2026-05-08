// Crie um sistema de cadastro de usuários.
// Cada usuário deve possuir: Nome, Idade, Email
// Regras:
// 1. Idade não pode ser negativa
// 2. E-mail não pode ser vazio
// 3. Todos os atributos devem ser privados
// 4. Utilizar getters/setters ou properties
// 5. Exibir dados cadastrados ao final

using Aula_12_Poo_Desafio;

Usuario novoUsuario = new Usuario();

novoUsuario.Nome = "Gabriel";
novoUsuario.Idade = 10;
novoUsuario.Email = "gb@email.com";

novoUsuario.ExibirCadastro();