/* Exercício 3 - Exceção customizada + validação
Crie ProdutoNaoEncontradoException : Exception com mensagem "Produto {id} não encontrado.".
Adicione à interface: Produto BuscarPorId(int id). Implemente lançando a exceção customizada via FirstOrDefault + operador ?? throw.
No Main, teste com um Id existente e um inexistente, tratando com try/catch. */

using Aula_19_Exercicios.Modelos;

namespace Aula_19_Exercicios.Excecoes
{
    class ProdutoNaoEncontradoException : Exception
    {
        public ProdutoNaoEncontradoException(int id)
        : base($"Produto ID: {id} não encontrado.")
        {
        }
    }
}