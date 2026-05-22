// Exercicio 4 - Sistema de notificações
// Classe abstrata 'Notificacao' com Mensagem e método abstrato Enviar()
// Classe 'Email' exibe: Email enviado: [mensagem]
// Classe 'SMS' exibe: SMS enviado: [mensagem]
// Classe 'Push' exibe: Notificação Push: [mensagem]
// Crie uma List<Notificacao> e dispare todas as notificações de uma vez

using Aula_14_Poo_Exercicio_4;

List<Notificacao> notificacoes =
[
    new Email("123"),
    new SMS("!@#"),
    new Push("ASD")
];

foreach (Notificacao notificacao in notificacoes)
{
    Console.WriteLine(notificacao.Enviar());
};