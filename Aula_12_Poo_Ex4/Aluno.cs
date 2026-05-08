// Crie classe aluno com: property nome e nota
// Regras: nota deve ficar entre 0 e 10, exibir os dados do aluno

namespace Aula_12_Poo_Ex4
{
    internal class Aluno
    {
        private string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private decimal nota;
        public decimal Nota
        {
            get { return nota; }

            set
            {
                if (value >= 0 && value <= 10)
                {
                    nota = value;
                }
            }
        }
    }
}