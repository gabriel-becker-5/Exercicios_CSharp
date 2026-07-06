namespace Aula_MVC_04_Exercicios.Models
{
    public class Aluno
    {
        public int Id { get;  set; }
        public string Nome { get;  set; }
        public string Email { get;  set; }
        public DateTime DataNascimento { get;  set; }
        public string Telefone { get;  set; }

        public Aluno(string nome, string email, DateTime datanascimento, string telefone)
        {
            Nome = nome;
            Email = email;
            DataNascimento = datanascimento;
            Telefone = telefone;
        }

        public Aluno()
        {
            
        }
    }
}