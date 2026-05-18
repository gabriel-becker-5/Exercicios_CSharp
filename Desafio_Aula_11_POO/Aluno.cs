// Desafio Aula 11 POO
// Crie um sistema de Alunos
// Com as funções: Cadastrar aluno, listar alunos, mostrar média da turma e mostrar quantos foram aprovados

namespace Desafio_Aula_11_POO
{
    internal class Aluno
    {
        public string nomeAluno { get; set; }
        public decimal Nota { get; set; }

        public Aluno(string NomeAluno, decimal nota)
        {
            nomeAluno = NomeAluno;
            Nota = nota;
        }

        public void Apresentacao()
        {
            Console.WriteLine($"{nomeAluno}");
        }

        public void ApresentacaoCompleta()
        {
            string status = EhAprovado() ? "Aprovado" : "Reprovado";
            Console.WriteLine($"{nomeAluno}  | {Nota}  | {status}");
        }

        public bool EhAprovado()
        {
            return Nota >= 7;

        }

    }
}