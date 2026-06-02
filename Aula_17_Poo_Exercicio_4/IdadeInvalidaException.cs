namespace Aula_17_Poo_Exercicio_4
{
    class IdadeInvalidaException : Exception
    {
        public IdadeInvalidaException()
            : base("Idade inválida! Digite um número entre 0 e 150.")
        {
        }
    }
}