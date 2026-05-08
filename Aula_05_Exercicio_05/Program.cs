// utilize um for para repetir 3 vezes
// dentro de cada tentativa, peça um numero ao usuário
// utilize um while para garantir que o número digitado seja maior que 0 e se o numero for maior que 10, exiba "Número alto", senão "Número baixo"
// após validar, exiba o número digitado
// ao final das três repetições mostre a mensagem "programa finalizado"

const int MAX_TENTATIVAS = 3;
int numeroDigitado = 0;

for (int i = 1; i <= MAX_TENTATIVAS; ++i)
{
    while (numeroDigitado <= 0)
    {
        Console.Write("Informe o " + i + "º número: ");
        numeroDigitado = int.Parse(Console.ReadLine());
    }

    Console.WriteLine("Número escolhido: " + numeroDigitado);

    if (numeroDigitado > 10)
    {
        Console.WriteLine("Número alto!");
    }
    else
    {
        Console.WriteLine("Número baixo!");
    }
    numeroDigitado = 0;
}
Console.WriteLine("Programa finalizado!");