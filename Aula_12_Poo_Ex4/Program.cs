// Crie classe aluno com: property nome e nota
// Regras: nota deve ficar entre 0 e 10, exibir os dados do aluno

using Aula_12_Poo_Ex4;

Aluno novoAluno = new Aluno();

novoAluno.Nome = "Gabriel";
novoAluno.Nota = 7.5m;

Console.WriteLine($"Nome: {novoAluno.Nome}. Nota: {novoAluno.Nota}");