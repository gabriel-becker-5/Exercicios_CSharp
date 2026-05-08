// Crie um programa que: mostre numeros de 1 até 10 utilizando while

int contador = 0;
int numeroDigitado;

while (contador < 10)
{
    contador++;
    Console.Write("Digite o " + contador + "º número: ");
    numeroDigitado = int.Parse(Console.ReadLine());
}