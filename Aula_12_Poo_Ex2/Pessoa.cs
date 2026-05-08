// Crie classe Pessoa
// Atributo privado idade
// Não permitir idade negativa
// Exibir a idade cadastrada
namespace Aula_12_Poo_Ex2
{
    internal class Pessoa
    {
        private int _idade;
        public int Idade
        {
            get { return _idade; }
            set
            {
                if (value >= 0 && value <= 130)
                {
                    _idade = value;
                }
            }
        }
    }
}