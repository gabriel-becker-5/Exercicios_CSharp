namespace Aula_14_Poo_Exercicio_4
{
    public class SMS : Notificacao
    {
        public override string Enviar()
        {
            return $"SMS enviado: [{Mensagem}].";
        }

        public SMS(string mensagem) : base(mensagem)
        {
        }
    }
}