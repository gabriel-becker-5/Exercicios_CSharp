namespace Aula_14_Poo_Exercicio_4
{
    public abstract class Notificacao
    {
        public string Mensagem { get; private set; }

        public abstract string Enviar();

        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}