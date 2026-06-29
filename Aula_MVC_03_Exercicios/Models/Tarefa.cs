namespace Aula_MVC_03_Exercicios.Models
{
    public class Tarefa
    {
        public string Titulo { get; private set; }
        public bool Concluida { get; private set; }

        public Tarefa(string titulo, bool concluida)
        {
            Titulo = titulo;
            Concluida = concluida;
        }
    }
}