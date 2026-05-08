// Crie classe Produto
// Possuir atributo privado nome
// Crie SetNome()
// Crie GetNome()
// Exiba o nome cadastrado

namespace Aula_12_Poo_Ex1
{
    internal class Produto
    {
        private string nome;

        public void SetNome(string nomeProduto)
        {
            nome = nomeProduto;
        }

        public string GetNome()
        {
            return nome;
        }
    }
}