namespace Aula_17_Poo_Desafio
{
    class ValorInvalidoException : Exception
    {
        public ValorInvalidoException()
    : base("Valor inválido, por favor informe um valor positivo.")
        {
        }
    }
}