namespace Aula_13_Poo_Exercicio_4
{
    public abstract class Funcionario
    {
        public string Nome { get; protected set; }
        public abstract decimal CalcularSalario();

        protected Funcionario(string nome)
        {
            Nome = nome;
        }
    }
}