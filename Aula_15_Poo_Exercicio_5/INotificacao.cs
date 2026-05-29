namespace Aula_15_Poo_Exercicio_5
{
    interface INotificacao
    {
        /// <summary>
        /// Envia notificação aos usuários (SMS ou Email)
        /// </summary>
        void Enviar(string msg);
    }
}