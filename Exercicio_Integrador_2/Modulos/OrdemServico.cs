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
            Numero = numero;
            Cliente = cliente;
            Veiculo = veiculo;
            FuncionarioResponsavel = funcionarioResponsavel;
            ListaServicos = listaservicos;
            ListaPecas = listapecas;
            DataAbertura = dataabertura;
            Status = status;
        }

        public void FinalizarOrdemServico()
        {
            Status = StatusOrdemServico.Finalizada;
        }

        public void CancelarOrdemServico()
        {
            Status = StatusOrdemServico.Cancelada;
        }

        public void DetalharOrdemServico()
        {
            Console.WriteLine($"====================== Ordem de Serviço nº: {Numero} ======================");
            Console.WriteLine($"Status: {Status} | Data Abertura: {DataAbertura}");
            Console.WriteLine($"Cliente: {Cliente.Nome} - {Cliente.GetType().Name}");
            Console.WriteLine($"Veículo: {Veiculo.Placa}  |  {Veiculo.Marca} {Veiculo.Modelo} {Veiculo.AnoFabricacao}");
            Console.WriteLine($"Responsável: {FuncionarioResponsavel.Nome} | {FuncionarioResponsavel.Cargo}");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("| Relação de Peças & Serviços");
            Console.WriteLine("-------------------------------------------------------------------");

            decimal valorTotalPecas = 0;
            decimal valorTotalServicos = 0;

            foreach (Peca peca in ListaPecas)
            {
                Console.WriteLine($"- {peca.Nome} | Valor Unitário: {peca.PrecoUnitario:C2} | Quantidade: 1");
                valorTotalPecas += peca.PrecoUnitario;
            }
            
            foreach (Servico servico in ListaServicos)
            {
                Console.WriteLine($"- {servico.Nome} | Valor Hora: {servico.ValorBase:C2} | Tempo Execução: {servico.TempoEstimadoHoras} hora(s)");
                valorTotalServicos += servico.ValorBase * servico.TempoEstimadoHoras;
            }

            decimal valorTotalOS = valorTotalPecas + valorTotalServicos;

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine($"Peças: {valorTotalPecas:C2}");
            Console.WriteLine($"Serviços: {valorTotalServicos:C2}");
            Console.WriteLine($"Valor Total: {valorTotalOS:C2}");
            Console.WriteLine("====================================================================");
        }
    }
}