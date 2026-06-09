// Objetivo: Tratar erros em código assíncrono
// Crie o método: static async Task<int> DividirAsync(int a, int b)
// Simule delay de 500ms
// Lance ArgumentException se b == 0
// Retorne a / b
// No Main, chame o método dentro de try/catch/finally:
// Teste com b=5 (sucesso) e b=0 (erro)
// Finally: sempre exiba 'Operação concluída'

async Task<int> DividirAsync(int a, int b)
{
    if (b == 0)
        throw new ArgumentException("O número divisor não pode ser zero.");

    await Task.Delay(500);
    return a / b;  
}

try
{
    Console.WriteLine($"Resultado da Divisão: {await DividirAsync(50, 5)}.");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}
finally
{
    Console.WriteLine("Operação concluída.");
}

try
{
    Console.WriteLine($"Resultado da Divisão: {await DividirAsync(10, 0)}.");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}
finally
{
    Console.WriteLine("Operação concluída.");
}