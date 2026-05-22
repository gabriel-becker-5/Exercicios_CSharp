namespace Aula_14_Poo_Exercicio_5
{
    public class Gerente : Funcionario
    {
        public const decimal aliquotaBonusGerente = 0.30m;

        public Gerente(string nome, decimal salario) : base(nome, salario)
        {
        }

        public override decimal CalcularBonus()
        {
            return Salario * aliquotaBonusGerente;
        }
    }
}