using Exercicio_Integrador_2.Pessoas;

namespace Exercicio_Integrador_2.Repository
{
    public class FuncionarioRepository
    {
        public List<Funcionario> Funcionarios = new List<Funcionario>
        {
            new Funcionario(1, "Marlon", "47 98888-9999", "marlon@email.com", "Gerente", 15000),
            new Funcionario(2, "Kassio", "47 98888-9999", "kassio@email.com", "Mecânico Sênior", 6500),
            new Funcionario(3, "Alan", "47 98888-9999", "alan@email.com", "Mecânico Júnior", 3000)
        };

        public int QtdFuncionariosCadastrados()
        {
            return Funcionarios.Count();
        }

        public void CadastrarFuncionario(Funcionario funcionario)
        {
            Funcionarios.Add(funcionario);
        }

        public List<Funcionario> ListarFuncionarios()
        {
            return Funcionarios;
        }

        public bool PesquisarFuncionarioPorNome(string nome)
        {
            int qtdFuncionariosCadastrados = Funcionarios.Count(c => c.Nome.ToUpper() == nome.ToUpper());

            if (qtdFuncionariosCadastrados == 0)
            {
                return false;
            }
            return true;
        }

        public Funcionario PesquisarFuncionarioPorID(int id)
        {
            return Funcionarios.FirstOrDefault(f => f.Id == id);
        }
    }
}