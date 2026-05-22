namespace Aula_14_Poo_Exercicio_5
{
    public abstract class Funcionario
    {
        public string Nome { get; private set; }
        public decimal Salario { get; private set; }
        public virtual decimal CalcularBonus()
        {
            return 0;
        }

        public Funcionario(string nome, decimal salario)
        {
            Nome = nome;
            Salario = salario;
        }

        public decimal SalarioTotal()
        {
            return Salario + CalcularBonus();
        }
    }
}