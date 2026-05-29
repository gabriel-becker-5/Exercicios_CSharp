namespace Aula_15_Poo_Exercicio_5
{
    public class NotificacaoSMS : INotificacao
    {
        public void Enviar(string msg)
        {
            Console.WriteLine($"SMS enviado: {msg}");
        }
    }
}