namespace Aula_12_Poo_Ex1
{
    class Pessoa
    {
        private string Nome { get; set; }

        private double salario;

        public double Salario
        {
            get { return salario; }

            set
            {
                if (value >= 0)
                {
                    salario = value;
                }
            }
        }

        public void SetNome(string novoNome)
        {
            Nome = novoNome;
        }

        public string GetNome()
        {
            return Nome;
        }
    }
}