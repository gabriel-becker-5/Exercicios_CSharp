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
            string valorBaseServicoString = Console.ReadLine();
            bool ehValorServicoValido = _servicoService.EhValorServicoValido(valorBaseServicoString);

            while (!ehValorServicoValido)
            {
                Console.WriteLine("Digite um número válido!");
                Console.Write("Informe o Valor Base por Hora: ");
                valorBaseServicoString = Console.ReadLine();
                ehValorServicoValido = _servicoService.EhValorServicoValido(valorBaseServicoString);
            }

            Console.Write("Informe o Tempo Estimado em Horas: ");
            string tempoEstimadoServicoString = Console.ReadLine();
            bool ehTempoEstimadoValido = _servicoService.EhTempoEstimadoValido(tempoEstimadoServicoString);

            while (!ehTempoEstimadoValido)
            {
                Console.WriteLine("Digite um número válido!");
                Console.Write("Informe o Tempo Estimado em Horas: ");
                tempoEstimadoServicoString = Console.ReadLine();
                ehTempoEstimadoValido = _servicoService.EhTempoEstimadoValido(tempoEstimadoServicoString);
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