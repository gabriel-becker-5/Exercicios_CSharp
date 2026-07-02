using Exercicio_Integrador_2.Models;

namespace Exercicio_Integrador_2.Repository
{
    public class OrdemServicoRepository
    {
        public List<OrdemServico> OrdensDeServico = new List<OrdemServico>();

        public OrdemServicoRepository()
        {
        }

        public int QtdOrdensServicoCriadas()
        {
            return OrdensDeServico.Count();
        }

        public void CadastrarOS(OrdemServico os)
        {
            OrdensDeServico.Add(os);
        }

        public void AddServicoNaOS(OrdemServico os, List<Servico> listaServicos)
        {
            foreach (var servico in listaServicos)
            {
                os.ListaServicos.Add(servico);
            }
        }

        public void AddPecaNaOS(OrdemServico os, List<Peca> listaPecas)
        {
            foreach (var peca in listaPecas)
            {
                os.ListaPecas.Add(peca);
            }
        }

        public void FinalizarOS(OrdemServico os)
        {
            os.FinalizarOrdemServico();
        }

        public void CancelarOS(OrdemServico os)
        {
            os.CancelarOrdemServico();
        }

        public OrdemServico PesquisarOSporID(int id)
        {
            return OrdensDeServico.FirstOrDefault(os => os.Id == id);
        }

        public List<OrdemServico> ListarTodasOS()
        {
            return OrdensDeServico;
        }
    }
}