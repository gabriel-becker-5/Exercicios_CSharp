namespace Exercicio_Integrador_2.Interfaces
{
    internal class NotificacaoWPP : INotificavel
    {
        public async Task ConfirmarAgendamentosAsync(string mensagem)
        {
            await Task.Delay(5000);
            Console.WriteLine($"Notificação de Confirmação de Agendamento enviada. Conteúdo: {mensagem}");
        }

        public async Task ConclusaoOrdemDeServicoAsync(string mensagem)
        {
            await Task.Delay(15000);
            Console.WriteLine($"Notificação de Conclusão de Ordem de Serviço enviada. Conteúdo: {mensagem}");
        }
    }
}