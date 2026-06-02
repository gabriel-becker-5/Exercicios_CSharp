// Usar try / catch básico
// Crie um programa que peça ao usuário um número inteiro
// Use int.Parse() para converter a entrada
// Trate com try/catch:
// FormatException -> 'Digite apenas números inteiros'
// Exception genérica -> exiba ex.Message
// Teste com entradas válidas e inválidas (ex: 'abc', '3.14')

try
{
    Console.Write($"Informe um número inteiro: ");
    int numeroInteiro = int.Parse(Console.ReadLine());
}
catch (FormatException)
{
    Console.WriteLine("Digite apenas números inteiros.");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro inesperado: {ex.Message}");
}