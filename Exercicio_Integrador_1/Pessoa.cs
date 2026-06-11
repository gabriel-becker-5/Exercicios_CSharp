namespace Exercicio_Integrador_1
{
    public abstract class Pessoa
    {
        public int Id {  get; private set; }
        public string Nome { get; private set; }
        public abstract string ObterDescricao();
        public Pessoa(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}