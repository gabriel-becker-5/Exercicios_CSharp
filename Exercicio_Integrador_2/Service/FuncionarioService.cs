using Exercicio_Integrador_2.Pessoas;
using Exercicio_Integrador_2.Repository;

namespace Exercicio_Integrador_2.Service
{
    public class FuncionarioService
    {
        private readonly FuncionarioRepository _funcionarioRepository;

        public FuncionarioService(FuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
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

            Funcionario novoFuncionario = new Funcionario(_funcionarioRepository.QtdFuncionariosCadastrados()+1, 
                                                          nomeFuncionario, 
                                                          telefoneFuncionario, 
                                                          emailFuncionario, 
                                                          cargoFuncionario, 
                                                          salarioFuncionario);

            _funcionarioRepository.CadastrarFuncionario(novoFuncionario);
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

            foreach (Funcionario funcionario in _funcionarioRepository.ListarFuncionarios())
            {
                Console.WriteLine(funcionario.ExibirDados());
            }
            Console.WriteLine();
        }
    }
}