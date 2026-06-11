namespace Exercicio_Integrador_1
{
    public class LivroIndisponivelException : Exception
    {
        public LivroIndisponivelException() : base("Livro indisponível ou emprestado.")
        { }
    }
}