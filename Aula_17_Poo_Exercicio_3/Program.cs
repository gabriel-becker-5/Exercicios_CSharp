// Multiplos Catch com exceções específicas
// Crie um menu que pede um número e divide 100 por ele
// Trate com múltiplos catch (do mais específico ao mais genérico)
// DivideByZeroException -> 'Não pode dividir por zero'
// FormatException -> 'Digite apenas números'
// OverflowException -> 'Número muito grande'
// Exception -> 'Erro inesperado: + msg'
// Teste cada caso

const int DIVIDENDO = 100;

decimal dividir (decimal divisor)
{
    return DIVIDENDO / divisor;   
}

try
{
    Console.Write("Informe um divisor: ");
    decimal numeroDivisor = decimal.Parse(Console.ReadLine());
    Console.WriteLine(dividir(numeroDivisor));
}
catch (DivideByZeroException)
{
    Console.WriteLine("Não é possível dividir por zero.");
}
catch (FormatException)
{
    Console.WriteLine("Digite apenas números.");
}
catch (OverflowException)
{
    Console.WriteLine("Número muito grande.");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro inesperado: {ex.Message}");
}