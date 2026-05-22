namespace Aula_14_Poo_Exercicio_4
{
    public class Email : Notificacao
    {

        public override string Enviar()
        {
            return $"E-mail enviado: [{Mensagem}].";
        }

        public Email(string mensagem) : base(mensagem)
        {
        }

    }
}