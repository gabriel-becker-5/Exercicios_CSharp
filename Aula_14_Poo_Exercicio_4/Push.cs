namespace Aula_14_Poo_Exercicio_4
{
    public class Push : Notificacao
    {

        public override string Enviar()
        {
            return $"Notificação Push: [{Mensagem}].";
        }

        public Push(string mensagem) : base(mensagem)
        {
        }
    }
}