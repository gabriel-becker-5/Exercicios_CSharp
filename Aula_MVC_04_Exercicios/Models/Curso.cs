namespace Aula_MVC_04_Exercicios.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }

        public Curso(string nome, int cargahoraria)
        {
            Nome = nome;
            CargaHoraria = cargahoraria;
        }

        public Curso()
        {
            
        }
    }
}