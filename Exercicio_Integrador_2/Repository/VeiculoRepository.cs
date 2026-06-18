using Exercicio_Integrador_2.Models;
using Exercicio_Integrador_2.Pessoas;

namespace Exercicio_Integrador_2.Repository
{
    public class VeiculoRepository
    {
        public List<Veiculo> Veiculos = new List<Veiculo>
        {
            new Caminhao("AAA-0A00", "VOLVO", "FH 540", 1990),
            new Caminhao("AAA-0A01", "VOLVO", "FH 460", 1991),
            new Caminhao("AAA-0A02", "SCANIA", "R450", 1992),
            new Caminhao("AAA-0A03", "SCANIA", "R500", 2000),
            new Caminhao("AAA-0A04", "VOLKSWAGEN", "DELIVERY 11180", 2005),
            new Carro("AAA-0A05", "VOLKSWAGEN", "GOL", 2009),
            new Carro("AAA-0A06", "VOLKSWAGEN", "POLO", 2015),
            new Carro("AAA-0A07", "FIAT", "ARGO", 2026),
            new Carro("AAA-0A08", "FIAT", "STRADA", 2000),
            new Carro("AAA-0A09", "CHEVROLET", "ONIX", 2019),
            new Carro("AAA-0A10", "CHEVROLET", "ONIX", 2020),
            new Carro("AAA-0A11", "TOYOTA", "COROLLA", 2021),
            new Carro("AAA-0A12", "BYD", "DOLPHIN", 2025),
            new Moto("AAA-0A13", "HONDA", "CG 160", 2019),
            new Moto("AAA-0A14", "YAMAHA", "FACTOR 150", 2023),
            new Moto("AAA-0A15", "YAMAHA", "FAZER", 2026),
            new Moto("AAA-0A16", "HONDA", "BIZ", 2026),
            new Moto("AAA-0A17", "HONDA", "BIZ", 2025),
            new Moto("AAA-0A18", "YAMAHA", "LANDER", 2025)
        };

        public void CadastrarVeiculo(Moto veiculo)
        {
            Veiculos.Add(veiculo);
        }

        public void CadastrarVeiculo(Carro veiculo)
        {
            Veiculos.Add(veiculo);
        }

        public void CadastrarVeiculo(Caminhao veiculo)
        {
            Veiculos.Add(veiculo);
        }

        public Veiculo PesquisarVeiculoPorPlaca(string placa)
        {
            return Veiculos.FirstOrDefault(v => v.Placa == placa);
        }

        public List<Veiculo> ListarTodosVeiculos()
        {
            return Veiculos;
        }
    }
}