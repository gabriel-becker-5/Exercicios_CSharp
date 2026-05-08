// Crie um programa que: peça dois numeros inteiros
// Mostre qual operação foi utilizada e o resultado para as seguintes operações

Console.Write("Forneça o 1º número: ");
int numero1 = int.Parse(Console.ReadLine());

Console.Write("Forneça o 2º número: ");
int numero2 = int.Parse(Console.ReadLine());

int soma = numero1 + numero2;
Console.WriteLine("Somando nº " + numero1 + " com o nº " + numero2 + ", resultado: " + soma);

int subtracao = numero1 - numero2;
Console.WriteLine("Subtraindo nº " + numero1 + " com o nº " + numero2 + ", resultado: " + subtracao);

int multiplicacao = numero1 * numero2;
Console.WriteLine("Multiplicando nº " + numero1 + " poelo nº " + numero2 + ", resultado: " + multiplicacao);

int divisao = numero1 / numero2;
Console.WriteLine("Dividindo nº " + numero1 + " pelo nº " + numero2 + ", resultado: " + divisao);