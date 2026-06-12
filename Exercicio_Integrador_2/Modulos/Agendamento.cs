/* Classe Agendamento - Representa um horário reservado.
Atributos: Id, Cliente, Veiculo, DataHora, Servico
Métodos: Confirmar(), Cancelar() */

using Exercicio_Integrador_2.Pessoas;
using Exercicio_Integrador_2.Veiculos;

namespace Exercicio_Integrador_2.Modulos
{
    public class Agendamento
    {
        public int Id { get; private set; }
        public Cliente Cliente { get; private set; }
        public Veiculo Veiculo { get; private set;}
        public DateTime DataHora { get; private set; }
        public List<Servico> Servico { get; private set; }
        public List<Peca> Peca { get; private set; }

        public Agendamento(int id, Cliente cliente, Veiculo veiculo, DateTime datahora, List<Servico> servico, List<Peca> peca)
        {
            Id = id;
            Cliente = cliente;
            Veiculo = veiculo;
            DataHora = datahora;
            Servico = servico;
            Peca = peca;
        }
    }
}