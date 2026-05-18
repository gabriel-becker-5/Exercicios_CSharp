namespace Aula_13_Poo_Exercicio_4
{
    public class CLT : Funcionario
    {
        public decimal SalarioMensal { get; private set; }

        public override decimal CalcularSalario()
        {
            return SalarioMensal;
        }

        public CLT(string nome, decimal salarioMensal) : base(nome)
        {
            Nome = nome;
            SalarioMensal = salarioMensal;
        }
    }
}