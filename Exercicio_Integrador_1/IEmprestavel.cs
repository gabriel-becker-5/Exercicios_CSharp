namespace Exercicio_Integrador_1
{
    public interface IEmprestavel
    {
        void Emprestar(int idLivro, int idPessoa, int qtdDiasEmprestimo);
        void Devolver(int idLivro);
    }
}