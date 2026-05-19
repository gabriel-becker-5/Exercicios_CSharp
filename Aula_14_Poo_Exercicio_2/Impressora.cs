namespace Aula_14_Poo_Exercicio_2
{
    public class Impressora
    {
        public string Imprimir(string texto)
        {
            return texto;
        }

        public string Imprimir(string texto, int vezes)
        {
            string textoExibicao = "";

            for (int i = 0; i < vezes; i++)
            {
                textoExibicao  += texto + "\n";
            }
            return textoExibicao;
        }

        public string Imprimir(string texto, string cor)
        {
            return $"[{cor}] {texto}";
        }
    }
}