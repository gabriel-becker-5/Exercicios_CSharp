// Peça um número ao usuário, repita até que o numero seja maior que 0

int numeroUsuario = 0;

do
{
    Console.Write("Informe um número maior do que zero: ");
    numeroUsuario = int.Parse(Console.ReadLine());
}
while (numeroUsuario <= 0);