namespace Exercicio_Integrador_1
{
    public class Livro : IEmprestavel
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }

        private int _ano;
        public int Ano
        {
            get { return _ano; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("O ano do livro deve ser positivo.");

                _ano = value;
            }
        }
        public bool IsDisponivel { get; set; }

        public Livro(int id, string titulo, string autor, int ano, bool isdisponivel)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            IsDisponivel = isdisponivel;
        }

        public void Emprestar(int idLivro, int idPessoa, int qtdDiasEmprestimo)
        {
            if (IsDisponivel)
            {
                IsDisponivel = false;
                Console.WriteLine("Livro emprestado com sucesso.");
            }
            else
                throw new LivroIndisponivelException();
        }

        public void Devolver(int id)
        {
            if (!IsDisponivel)
            {
                IsDisponivel = true;
                Console.WriteLine("Livro devolvido com sucesso.");
            }
            else
                Console.WriteLine("Livro disponível não pode ser devolvido.");
        }

        public void DetalharCadastroLivro()
        {
            Console.WriteLine($"Id: {Id}  |  Título: {Titulo}  |  Autor: {Autor}  |  Publicação: {Ano}  |  Disponível? {IsDisponivel}");
        }
    }
}