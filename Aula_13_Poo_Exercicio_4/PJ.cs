namespace Aula_13_Poo_Exercicio_4
{
    public class PJ : Funcionario
    {
        public decimal salarioHora { get; private set; }
        public decimal horasTrabalhadas { get; private set; }

        public override decimal CalcularSalario()
        {
            return salarioHora * horasTrabalhadas;
        }

        public PJ(string nome,  decimal SalarioHora, decimal HorasTrabalhadas) : base(nome)
        {
            Nome = nome;
            salarioHora = SalarioHora;
            horasTrabalhadas = HorasTrabalhadas;
        }
    }
}