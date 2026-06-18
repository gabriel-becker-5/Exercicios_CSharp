using Exercicio_Integrador_2.Models;

namespace Exercicio_Integrador_2.Repository
{
    public class PecaRepository
    {
        public List<Peca> Pecas = new List<Peca>
        {
            new Peca(1, "Bieleta", 0, 100.50m),
            new Peca(2, "Filtro de Óleo", 10, 25.90m),
            new Peca(3, "Filtro de Ar", 8, 35.50m),
            new Peca(4, "Pastilha de Freio", 12, 89.90m),
            new Peca(5, "Disco de Freio", 6, 180.00m),
            new Peca(6, "Amortecedor Dianteiro", 4, 320.00m),
            new Peca(7, "Amortecedor Traseiro", 4, 295.00m),
            new Peca(8, "Correia Dentada", 5, 145.00m),
            new Peca(9, "Bateria 60Ah", 3, 450.00m),
            new Peca(10, "Velas de Ignição", 20, 18.50m),
            new Peca(11, "Bobina de Ignição", 7, 220.00m),
            new Peca(12, "Radiador", 2, 580.00m),
            new Peca(13, "Bomba de Combustível", 5, 310.00m),
            new Peca(14, "Rolamento de Roda", 9, 75.00m),
            new Peca(15, "Terminal de Direção", 11, 68.90m)
        };

        public int QtdPecasCriadas()
        {
            return Pecas.Count();
        }

        public void CadastrarPeca(Peca peca)
        {
            Pecas.Add(peca);
        }

        public Peca PesquisarPecaPorID(int id)
        {
            Peca pecaSelecionada = Pecas.FirstOrDefault(p => p.Id == id);
            return pecaSelecionada;
        }

        public List<Peca> ListarTodasPecas()
        {
            return Pecas;
        }

        public List<Peca> ListarPecasEscolhidas(List<int> ids)
        {
            var pecasSelecionadas = new List<Peca>();

            foreach (int id in ids)
            {
                var peca = Pecas.FirstOrDefault(p => p.Id == id);
                pecasSelecionadas.Add(peca);
            }

            return pecasSelecionadas;
        }
    }
}