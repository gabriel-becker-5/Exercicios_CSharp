namespace Exercicio_Integrador_1
{
    public class Professor : Pessoa
    {
        public string Materia { get; private set; }

        public Professor(int id, string nome, string materia) : base(id, nome)
        {
            Materia = materia;
        }
        public override string ObterDescricao()
        {
            return $"Id Cadastral: {Id}  |  Nome do Professor: {Nome}  |  Matéria: {Materia}";
        }
    }
}