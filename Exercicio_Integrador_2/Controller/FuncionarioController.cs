using Exercicio_Integrador_2.Service;

namespace Exercicio_Integrador_2.Controller
{
    public class FuncionarioController
    {
        private readonly FuncionarioService _funcionarioService;

        public FuncionarioController(FuncionarioService funcionarioservice)
        {
            _funcionarioService = funcionarioservice;
        }

        public void CadastrarFuncionario()
        {
            _funcionarioService.CadastrarFuncionario();
        }

        public void ListarFuncionarios()
        {
            _funcionarioService.ListarFuncionarios();
        }
    }
}