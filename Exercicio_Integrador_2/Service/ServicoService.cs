using Exercicio_Integrador_2.Models;
using Exercicio_Integrador_2.Repository;

namespace Exercicio_Integrador_2.Service
{
    public class ServicoService
    {
        private readonly ServicoRepository _servicoRepository;
        public ServicoService(ServicoRepository servicorepository)
        {
            _servicoRepository = servicorepository;
        }

        public void CadastrarServico()
        {
            Console.WriteLine("=== Cadastrar Serviço ===");
            Console.Write("Descrição do Serviço: ");
            string descricaoServico = Console.ReadLine();

            Console.Write("Informe o Valor Base por Hora: ");
            decimal valorBaseServico;
            string valorBaseServicoString = Console.ReadLine();
            bool ehValorServicoValido = decimal.TryParse(valorBaseServicoString, out valorBaseServico);

            while (!ehValorServicoValido || valorBaseServico <= 0)
            {
                Console.WriteLine("Digite um número válido!");
                Console.Write("Informe o Valor Base por Hora: ");
                valorBaseServicoString = Console.ReadLine();
                ehValorServicoValido = decimal.TryParse(valorBaseServicoString, out valorBaseServico);
            }

            Console.Write("Informe o Tempo Estimado em Horas: ");
            decimal tempoEstimadoServico;
            string tempoEstimadoServicoString = Console.ReadLine();
            bool ehTempoEstimadoValido = decimal.TryParse(tempoEstimadoServicoString, out tempoEstimadoServico);

            while (!ehTempoEstimadoValido || tempoEstimadoServico <= 0)
            {
                Console.WriteLine("Digite um número válido!");
                Console.Write("Informe o Tempo Estimado em Horas: ");
                tempoEstimadoServicoString = Console.ReadLine();
                ehTempoEstimadoValido = decimal.TryParse(tempoEstimadoServicoString, out tempoEstimadoServico);
            }

            Servico novoServico = new Servico(_servicoRepository.QtdServicosCriados()+1, 
                                              descricaoServico, 
                                              valorBaseServico, 
                                              tempoEstimadoServico);

            _servicoRepository.CadastrarServico(novoServico);
            Console.WriteLine("Serviço cadastrado com sucesso.");
            descricaoServico = "";
            valorBaseServico = 0;
            tempoEstimadoServico = 0;
            Console.WriteLine();
        }

        public void ListarServicos()
        {
            Console.WriteLine("=== Listar Serviços ===");
            List<Servico> listaServicos = _servicoRepository.ListarTodosServicos();
            foreach (Servico servico in listaServicos)
            {
                Console.WriteLine(servico.DetalharServico());
            }
            Console.WriteLine();
        }
    }
}