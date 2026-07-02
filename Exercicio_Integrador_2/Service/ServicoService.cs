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

        public void CadastrarServico(string descricao, 
                                     string valorbase, 
                                     string tempoestimadohoras)
        {
            decimal ValorBaseDecimal;
            decimal TempoEstimadoHorasDecimal;
            decimal.TryParse(valorbase, out ValorBaseDecimal);
            decimal.TryParse(tempoestimadohoras, out TempoEstimadoHorasDecimal);

            Servico novoServico = new Servico(_servicoRepository.QtdServicosCriados() + 1,
                                              descricao,
                                              ValorBaseDecimal,
                                              TempoEstimadoHorasDecimal);
            try
            {
                _servicoRepository.CadastrarServico(novoServico);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }          
        }

        public bool EhValorServicoValido(string valorServicoString)
        {
            decimal valorServico;
            bool ehValido = decimal.TryParse(valorServicoString, out valorServico);

            if (!ehValido || valorServico <= 0)
            {
                return false;
            }
            return true;
        }

        public bool EhTempoEstimadoValido(string tempoEstimadoString)
        {
            decimal tempoEstimado;
            bool ehValido = decimal.TryParse(tempoEstimadoString, out tempoEstimado);

            if (!ehValido || tempoEstimado <= 0)
            {
                return false;
            }
            return true;
        }

        public List<Servico> ListarServicos()
        {
            return _servicoRepository.ListarTodosServicos();
        }
    }
}