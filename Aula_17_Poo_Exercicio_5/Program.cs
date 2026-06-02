// TryParse e validação sem exceção
// Crie um programa de calculadora simples
// 1. Peça dois números ao usuário
// 2. Use int.TryParse para validar cada entrada
// 3. Se inválido, peça novamente (use um loop while)
// 4. Peça a operação, +, -, *, /
// 5. Para divisão, verifique se o divisor é diferente de 0 antes de calcular
// 6. Exiba o resultado ou mensagens de erro apropriadas

string input;
string operacao;
double primeiroNumero;
double segundoNumero;
double resultado = 0;
int tentativa = 0;

Console.WriteLine("===== Bem vindo a Calculadora Entra 21 =====");
do
{
    tentativa++;
    if (tentativa > 1)
    {
        Console.WriteLine("Entrada inválida!");
    }
    Console.Write("Informe o Primeiro Número: ");
    input = Console.ReadLine();
}
while (!double.TryParse(input, out primeiroNumero));

tentativa = 0;
do
{
    tentativa++;
    if (tentativa > 1)
    {
        Console.WriteLine("Entrada inválida!");
    }
    Console.Write("Informe o Segundo Número: ");
    input = Console.ReadLine();
}
while (!double.TryParse(input, out segundoNumero));

tentativa = 0;
do
{
    tentativa++;
    if (tentativa > 1)
    {
        Console.WriteLine("Operação inválida! Escolha uma: +, -, /, *");
    }
    Console.Write("Informe a Operação (+, -, /, *): ");
    operacao = Console.ReadLine();
} while (operacao != "+" && operacao != "-" && operacao != "/" && operacao != "*");

switch (operacao)
{
    case "+":
        resultado = primeiroNumero + segundoNumero;
        break;

    case "-":
        resultado = primeiroNumero - segundoNumero;
        break;

    case "/":
        if (segundoNumero != 0)
        {
            resultado = primeiroNumero / segundoNumero;
        }
        else
        {
            Console.WriteLine("Operação não permitida! Divisão por zero.");
            return;
        }
        break;

    case "*":
        resultado = primeiroNumero * segundoNumero;
        break;
}

Console.WriteLine($"Resultado: {resultado}");