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

        public void CadastrarFuncionario(string nome, 
                                         string telefone, 
                                         string email, 
                                         string cargo, 
                                         decimal salario)
        {
            Funcionario novoFuncionario = new Funcionario(_funcionarioRepository.QtdFuncionariosCadastrados() + 1,
                                                          nome,
                                                          telefone,
                                                          email,
                                                          cargo,
                                                          salario);

            try
            {
                _funcionarioRepository.CadastrarFuncionario(novoFuncionario);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        public List<Funcionario> ListarFuncionarios()
        {
            return _funcionarioRepository.ListarFuncionarios();
        }
    }
}