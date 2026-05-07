// DESAFIO AULA 11 POO
// OBJETIVO: SIMULAÇÃO REAL
// ENUNCIADO: CRIE UM SISTEMA DE ALUNOS
// 1. CADASTRAR ALUNOS
// 2. LISTAR ALUNOS
// 3. MOSTRAR MÉDIA DA TURMA
// 4. MOSTRAR QUANTOS FORAM APROVADOS

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