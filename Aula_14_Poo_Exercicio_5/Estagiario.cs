namespace Aula_14_Poo_Exercicio_5
{
    public class Estagiario : Funcionario
    {
        public Estagiario(string nome, decimal salario) : base(nome, salario)
        {
        }

        public override decimal CalcularBonus()
        {
            return 0;
        }
    }
}