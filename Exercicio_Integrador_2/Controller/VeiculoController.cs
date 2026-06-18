using Exercicio_Integrador_2.Service;

namespace Exercicio_Integrador_2.Controller
{
    public class VeiculoController
    {
        private readonly VeiculoService _veiculoService;

        public VeiculoController(VeiculoService veiculoservice)
        {
            _veiculoService = veiculoservice;
        }

        public void CadastrarVeiculo()
        {
            _veiculoService.CadastrarVeiculo();
        }

        public void ListarVeiculos()
        {
            _veiculoService.ListarVeiculos();
        }
    }
}