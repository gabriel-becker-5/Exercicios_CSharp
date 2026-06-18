using Exercicio_Integrador_2.Models;

namespace Exercicio_Integrador_2.Repository
{
    public class ServicoRepository
    {
        public List<Servico> Servicos = new List<Servico>
        {
            new Servico(1, "Alinhamento", 100.00m, 2),
            new Servico(2, "Balanceamento", 80.00m, 1),
            new Servico(3, "Troca de Óleo", 120.00m, 1),
            new Servico(4, "Revisão Completa", 450.00m, 6),
            new Servico(5, "Diagnóstico Eletrônico", 150.00m, 2),
            new Servico(6, "Troca de Pastilhas de Freio", 180.00m, 3),
            new Servico(7, "Substituição de Amortecedores", 350.00m, 4)
        };

        public int QtdServicosCriados()
        {
            return Servicos.Count();
        }

        public void CadastrarServico(Servico servico)
        {
            Servicos.Add(servico);
        }

        public Servico PesquisarServicoPorID(int id)
        {
            Servico servicoSelecionado = Servicos.FirstOrDefault(s => s.Id == id);
            return servicoSelecionado;
        }

        public List<Servico> ListarTodosServicos()
        {
            return Servicos;
        }

        public List<Servico> ListarServicosEscolhidos(List<int> ids)
        {
            var servicosSelecionados = new List<Servico>();

            foreach (int id in ids)
            {
                var servico = Servicos.FirstOrDefault(s => s.Id == id);
                servicosSelecionados.Add(servico);
            }

            return servicosSelecionados;
        }
    }
}