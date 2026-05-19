// Exercício 2 - Sobrecarga de métodos
// Crie uma classe 'Impressora' com o método Imprimir() sobrecarregado
// Imprimir(string texto) -> exibe texto
// Imprimir(string texto, int vezes) -> exibe o texto N vezes
// Imprimir(string texto, string cor) -> exibe "[COR] texto"
// Teste as três versões no Program.cs

using Aula_14_Poo_Exercicio_2;

Impressora impressoraDaSala = new Impressora();

Console.WriteLine(impressoraDaSala.Imprimir("Teste"));

Console.WriteLine(impressoraDaSala.Imprimir("Isso é um teste", 3));

Console.WriteLine(impressoraDaSala.Imprimir("Ainda testando", "AZUL"));