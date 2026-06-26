using Exercicio_Integrador_2.Models;

namespace Exercicio_Integrador_2.Repository
{
    public class OrdemServicoRepository
    {
        public List<OrdemServico> OrdensDeServico { get; set; }

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