// Interface + Convenções integradas
// Crie um mini-sistema de notificações
// Interface INotificacao com método Enviar(string msg)
// Classes: NotificacaoEmail e NotificacaoSMS
// Aplique todas as convenções de nomenclatura
// Adicione documentação XML em todos os métodos
// Use List<INotificacao> para enviar para vários canais

using Aula_15_Poo_Exercicio_5;

List<INotificacao> notificacoes =
[
    new NotificacaoEmail(),
    new NotificacaoSMS()
];

foreach (INotificacao notificacao in notificacoes)
{
    notificacao.Enviar("Super desconto de R$ 50,00!");
}