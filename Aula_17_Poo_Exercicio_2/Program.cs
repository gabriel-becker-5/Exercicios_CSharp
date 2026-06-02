// Usar Try, Catch, Finally
// Crie um método SimularOperacao() que:
// Recebe dois inteiros (a, b)
// Calcula a / b
// Lança DivideByZeroExceptioin se b = 0
// No Main, chame o método dentro de try/catch/finally:
// Catch: exiba a mensagem de erro
// Finally: exiba sempre a mensagem 'Operação finalizada'

double SimularOperacao(int numero1, int numero2)
{
    if (numero2 == 0)
        throw new DivideByZeroException("Divisão por zero não é permitido.");
    return numero1 / numero2;
}

try
{
    Console.Write("Informe o primeiro número: ");
    int numero1 = int.Parse(Console.ReadLine());

    Console.Write("Informe o segundo número: ");
    int numero2 = int.Parse(Console.ReadLine());

    Console.WriteLine($"Resultado: {SimularOperacao(numero1, numero2)}");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}
finally
{
    Console.WriteLine("Operação finalizada.");
}