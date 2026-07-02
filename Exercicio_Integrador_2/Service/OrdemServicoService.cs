using Exercicio_Integrador_2.Models;
using Exercicio_Integrador_2.Pessoas;
using Exercicio_Integrador_2.Repository;

namespace Exercicio_Integrador_2.Service
{
    public class OrdemServicoService
    {
        private readonly OrdemServicoRepository _osRepository;
        private readonly ClienteRepository _clienteRepository;
        private readonly VeiculoRepository _veiculoRepository;
        private readonly FuncionarioRepository _funcionarioRepository;
        private readonly ServicoRepository _servicoRepository;
        private readonly PecaRepository _pecaRepository;

        public OrdemServicoService(OrdemServicoRepository osrepository)
        {
            _osRepository = osrepository;
        }

        public void CriarOrdemServico(string idClienteString,
                                      string placa,
                                      string idFuncionarioString,
                                      List<string> servicosListString,
                                      List<string> pecasListString,
                                      string statusOS)
        {
            List<Servico> servicosSelecionados = [];
            foreach (string servico in servicosListString)
            {
                Servico _servicoAtual = _servicoRepository.PesquisarServicoPorID(int.Parse(servico));
                servicosSelecionados.Add(_servicoAtual);
            }

            List<Peca> pecasSelecionadas = [];
            foreach (string peca in pecasListString)
            {
                Peca _pecaAtual = _pecaRepository.PesquisarPecaPorID(int.Parse(peca));
                pecasSelecionadas.Add(_pecaAtual);
            }

            try
            {
                OrdemServico novaOS = new OrdemServico(_osRepository.QtdOrdensServicoCriadas() + 1,
                                                       _clienteRepository.PesquisarClientePorID(int.Parse(idClienteString)),
                                                       _veiculoRepository.PesquisarVeiculoPorPlaca(placa),
                                                       _funcionarioRepository.PesquisarFuncionarioPorID(int.Parse(idFuncionarioString)),
                                                       servicosSelecionados,
                                                       pecasSelecionadas,
                                                       DateTime.UtcNow,
                                                       ConverteStringEmStatusOS(statusOS));
                _osRepository.CadastrarOS(novaOS);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool CadastroClienteEhValido(string idClienteString)
        {
            int idCliente;
            bool ehIdValida = int.TryParse(idClienteString, out idCliente);
            Cliente clienteSelecionado = _clienteRepository.PesquisarClientePorID(idCliente);
            if (clienteSelecionado == null || ehIdValida == false)
            {
                return false;
            }
            return true;
        }

        public bool PlacaEhValida(string placaVeiculo)
        {
            Veiculo veiculoSelecionado = _veiculoRepository.PesquisarVeiculoPorPlaca(placaVeiculo);
            if (veiculoSelecionado == null)
            {
                return false;
            }
            return true;
        }

        public bool FuncionarioEhValido(string idFuncionarioString)
        {
            int idFuncionario;
            bool ehIdValida = int.TryParse(idFuncionarioString, out idFuncionario);
            Funcionario funcionarioSelecionado = _funcionarioRepository.PesquisarFuncionarioPorID(idFuncionario);
            if (funcionarioSelecionado == null || ehIdValida == false)
            {
                return false;
            }
            return true;
        }

        public bool ServicoEhValido(string idServicoString)
        {
            int idServico;
            bool ehIdValida = int.TryParse(idServicoString, out idServico);
            Servico servicoSelecionado = _servicoRepository.PesquisarServicoPorID(idServico);
            if (servicoSelecionado == null || ehIdValida == false)
            {
                return false;
            }
            return true;
        }

        public bool PecaEhValida(string idPecaString)
        {
            int idPeca;
            bool ehIdValida = int.TryParse(idPecaString, out idPeca);
            Peca pecaSelecionada = _pecaRepository.PesquisarPecaPorID(idPeca);
            if (pecaSelecionada == null || ehIdValida == false)
            {
                return false;
            }
            return true;
        }

        public bool StatusOSEhValido(string statusOS)
        {
            if (statusOS.ToUpper() != "A" &&
                statusOS.ToUpper() != "P" &&
                statusOS.ToUpper() != "E" &&
                statusOS.ToUpper() != "F" &&
                statusOS.ToUpper() != "C")
            {
                return false;
            }
            return true;
        }

        public StatusOrdemServico ConverteStringEmStatusOS(string statusOS)
        {
            switch (statusOS)
            {
                case "P":
                    return StatusOrdemServico.AguardaPecas;
                case "E":
                    return StatusOrdemServico.EmAndamento;
                case "F":
                    return StatusOrdemServico.Finalizada;
                case "C":
                    return StatusOrdemServico.Cancelada;
            }
                return StatusOrdemServico.Agendada; // Status Default
        }

        public bool OSEhCadastrada(string ordemDeServicoString)
        {
            int idOrdemServico;
            bool ehOSValida = int.TryParse(ordemDeServicoString, out idOrdemServico);
            OrdemServico osSelecionada = _osRepository.PesquisarOSporID(idOrdemServico);
            if (osSelecionada == null || ehOSValida == false)
            {
                return false;
            }
            return true;
        }

        public void AdicionarServicoNaOS(string idOSstring, List<string> servicosListString)
        {
            List<Servico> servicosSelecionados = [];
            foreach (string servico in servicosListString)
            {
                Servico _servicoAtual = _servicoRepository.PesquisarServicoPorID(int.Parse(servico));
                servicosSelecionados.Add(_servicoAtual);
            }

            OrdemServico OS = _osRepository.PesquisarOSporID(int.Parse(idOSstring));

            try
            {
                _osRepository.AddServicoNaOS(OS, servicosSelecionados);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AdicionarPecasNaOS(string idOSstring, List<string> pecasListString)
        {
            List<Peca> pecasSelecionadas = [];
            foreach (string peca in pecasListString)
            {
                Peca _pecaAtual = _pecaRepository.PesquisarPecaPorID(int.Parse(peca));
                pecasSelecionadas.Add(_pecaAtual);
            }

            OrdemServico OS = _osRepository.PesquisarOSporID(int.Parse(idOSstring));

            try
            {
                _osRepository.AddPecaNaOS(OS, pecasSelecionadas);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FinalizarOS(string ordemDeServicoString)
        {
            int idOrdemServico;
            bool ehOSValida = int.TryParse(ordemDeServicoString, out idOrdemServico);
            OrdemServico osSelecionada = _osRepository.PesquisarOSporID(idOrdemServico);
            try
            {
                _osRepository.FinalizarOS(osSelecionada);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CancelarOS(string ordemDeServicoString)
        {
            int idOrdemServico;
            bool ehOSValida = int.TryParse(ordemDeServicoString, out idOrdemServico);
            OrdemServico osSelecionada = _osRepository.PesquisarOSporID(idOrdemServico);
            try
            {
                _osRepository.CancelarOS(osSelecionada);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<OrdemServico> ListarOrdensServicos()
        {
            return _osRepository.ListarTodasOS();
        }
    }
}