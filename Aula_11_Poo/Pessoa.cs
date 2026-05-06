namespace Aula_11_Poo
{
    internal class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        public void ExibirDadosPessoa()
        {
            Console.WriteLine($"Olá, meu nome é {Nome} e tenho {Idade} anos.");
        }

        public bool EhCadastrado(Pessoa[] pessoas, string nomePesquisa)
        {
            for (int i = 0; i < pessoas.Length; i++)
            {
                if (pessoas[i].Nome.ToLower().Equals(nomePesquisa.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}