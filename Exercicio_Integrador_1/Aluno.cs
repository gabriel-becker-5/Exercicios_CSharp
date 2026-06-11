namespace Exercicio_Integrador_1
{
    public class Aluno : Pessoa
    {
        public string Turma { get; private set; }
        public Aluno(int id, string nome, string turma) : base(id, nome)
        {
            Turma = turma;
        }
        public override string ObterDescricao()
        {
            return $"Id Cadastral: {Id}  |  Nome do Aluno: {Nome}  |  Turma: {Turma}";
        }
    }
}