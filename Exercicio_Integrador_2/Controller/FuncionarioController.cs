using Exercicio_Integrador_2.Pessoas;
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
            Console.WriteLine("=== Cadastrar Funcionário ===");
            Console.Write("Nome do Funcionário: ");
            string nomeFuncionario = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefoneFuncionario = Console.ReadLine();

            Console.Write("E-mail: ");
            string emailFuncionario = Console.ReadLine();

            Console.Write("Cargo: ");
            string cargoFuncionario = Console.ReadLine();

            Console.Write("Salário R$: ");
            string salarioFuncionarioString = Console.ReadLine();
            decimal salarioFuncionario;
            bool ehSalarioValido = decimal.TryParse(salarioFuncionarioString, out salarioFuncionario);

            while (!ehSalarioValido || salarioFuncionario <= 0)
            {
                Console.WriteLine("Digite um número válido!");
                Console.Write("Salário R$: ");
                salarioFuncionarioString = Console.ReadLine();
                ehSalarioValido = decimal.TryParse(salarioFuncionarioString, out salarioFuncionario);
            }

            try
            {
                _funcionarioService.CadastrarFuncionario(nomeFuncionario,
                                                         telefoneFuncionario,
                                                         emailFuncionario,
                                                         cargoFuncionario,
                                                         salarioFuncionario);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Funcionário cadastrado com sucesso.");
            Console.WriteLine();
            nomeFuncionario = "";
            telefoneFuncionario = "";
            emailFuncionario = "";
            cargoFuncionario = "";
            salarioFuncionario = 0;
        }

        public void ListarFuncionarios()
        {
            Console.WriteLine("=== Listar Funcionários ===");
            foreach (Funcionario funcionario in _funcionarioService.ListarFuncionarios())
            {
                Console.WriteLine(funcionario.ExibirDados());
            }
            Console.WriteLine();
        }
    }
}