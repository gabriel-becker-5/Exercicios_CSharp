// Desafio Extra
// Crie classe 'Aluno' com Nome e Nota
// Crie um metodo que exibe: Aprovado (>=7) e Reprovado (<7)

namespace Aula_10_Poo
{
    internal class Aluno
    {
        public string Nome { get; set; }
        public decimal Nota { get; set; }

        public bool EhAprovado()
        {
            if (Nota >= 7)
            {
                return true;
            }
            return false;
        }
    }
}