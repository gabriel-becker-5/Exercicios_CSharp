/* Exceções Personalizadas Obrigatórias
HorarioIndisponivelException: Lançada quando existir conflito de horário.
EstoqueInsuficienteException: Lançada quando uma peça não possuir quantidade suficiente.
ServicoInvalidoException: Lançada quando o serviço não puder ser executado naquele veículo.
Exemplo: Serviço destinado apenas a caminhões sendo solicitado para motos. */

namespace Exercicio_Integrador_2.Excecoes
{
    public class HorarioIndisponivelException : Exception
    {
        public HorarioIndisponivelException() : base("Agendamento indisponível ou já ocupado.")
        {
        }
    }
}