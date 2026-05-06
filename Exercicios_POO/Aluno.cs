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