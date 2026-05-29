namespace Aula_15_Poo_Exercicio_5
{
    public class NotificacaoEmail : INotificacao
    {
        public void Enviar(string msg)
        {
            Console.WriteLine($"Email enviado: {msg}");
        }
    }
}