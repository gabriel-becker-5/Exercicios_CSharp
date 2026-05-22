namespace Aula_14_Poo_Exercicio_5
{
    public class Desenvolvedor : Funcionario
    {
        public const decimal aliquotaBonusDesenvolvedor = 0.20m;

        public Desenvolvedor(string nome, decimal salario) : base(nome, salario)
        {
        }

        public override decimal CalcularBonus()
        {
            return Salario * aliquotaBonusDesenvolvedor;
        }
    }
}