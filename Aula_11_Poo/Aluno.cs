// Exercício 03
// Adicione um método VerificarSituacao()
// Se >=7 --> Aprovado. Se no Reprovado
// Exibir resultado ao final

namespace Aula_11_Poo
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