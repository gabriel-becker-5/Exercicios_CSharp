using Exercicio_Integrador_2.Models;
using Exercicio_Integrador_2.Service;

namespace Exercicio_Integrador_2.Controller
{
    public class ServicoController
    {
        private readonly ServicoService _servicoService;

        public ServicoController(ServicoService servicoservice)
        {
            _servicoService = servicoservice;
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

            try
            {
                _servicoService.CadastrarServico(descricaoServico, valorBaseServicoString, tempoEstimadoServicoString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Serviço cadastrado com sucesso.");
            descricaoServico = "";
            valorBaseServico = 0;
            tempoEstimadoServico = 0;
            Console.WriteLine();
        }

        public void ListarServicos()
        {
            Console.WriteLine("=== Listar Serviços ===");
            foreach (Servico servico in _servicoService.ListarServicos())
            {
                Console.WriteLine(servico.DetalharServico());
            }
            Console.WriteLine();
        }
    }
}