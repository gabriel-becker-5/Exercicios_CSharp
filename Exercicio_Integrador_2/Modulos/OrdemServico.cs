/* Classe OrdemServico - Representa o atendimento de um cliente.
Atributos: Numero, Cliente, Veiculo, FuncionarioResponsavel, ListaServicos, ListaPecas, DataAbertura e Status
Métodos: AdicionarServico(), AdicionarPeca(), CalcularValorTotal(), Finalizar(), Cancelar()
Enum Obrigatório - StatusOrdemServico
Criar os seguintes estados: Aberta, EmAndamento, AguardandoPecas, Finalizada, Cancelada */

using Exercicio_Integrador_2.Pessoas;
using Exercicio_Integrador_2.Veiculos;

namespace Exercicio_Integrador_2.Modulos
{
    public class OrdemServico
    {
        public int Numero { get; private set; }
        public Cliente Cliente { get; private set; }
        public Veiculo Veiculo { get; private set; }
        public Funcionario FuncionarioResponsavel { get; private set; }
        public List<Servico> ListaServicos { get; private set; }
        public List<Peca> ListaPecas { get; private set; }
        public DateTime DataAbertura { get; private set; }
        public StatusOrdemServico Status { get; private set; }

        public OrdemServico(int numero, Cliente cliente, Veiculo veiculo, Funcionario funcionarioResponsavel, 
                            List<Servico> listaservicos, List<Peca> listapecas, DateTime dataabertura, 
                            StatusOrdemServico status)
        {
        }
    }
}