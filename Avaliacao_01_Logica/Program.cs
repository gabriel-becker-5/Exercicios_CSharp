string primeiroInput, segundoInput, operacao;
bool isPrimeiroInputNumero, isSegundoInputNumero;
decimal numeroUm, numeroDois;
decimal resultado = 0;
string opcaoDeSaida = "X";
string opcaoHistorico = "H";
string[] historicoOperacoes = new string[10];
int contadorArray = 0;

Console.WriteLine("=== Calculadora ===");
Console.WriteLine("H - Acessar Histórico");
Console.WriteLine("X - Encerra o Programa");

// Loop Primeiro Número
while (true)
{
    Console.Write("Digite o primeiro número: ");
    primeiroInput = Console.ReadLine().ToUpper();
    isPrimeiroInputNumero = decimal.TryParse(primeiroInput, out numeroUm);

    if (isPrimeiroInputNumero)
        break;
    else if (primeiroInput == opcaoDeSaida)
        return;
    else if (primeiroInput == opcaoHistorico)
        Console.WriteLine("Não há histórico para exibir.");
    else
        Console.WriteLine("Comando inválido! Digite 'X' para Encerrar, 'H' para Histórico, ou um número para calcular.");
}

// Loop Principal - segundo número em diante
while (true)
{
    // Loop validação da operação
    while (true)
    {
        Console.Write("Escolha uma operação (+, -, /, *): ");
        operacao = Console.ReadLine().ToUpper();

        if (operacao == "+" || operacao == "-" || operacao == "/" || operacao == "*")
            break;
        else if (operacao == opcaoDeSaida)
            return;
        else if (operacao == opcaoHistorico)
            if (historicoOperacoes.Count(h => h == null) == 10)
                Console.WriteLine("Não há histórico para exibir.");
            else
            {
                int itensImpressos = 0;
                int numeroExibicao = 11;
                for (int i = contadorArray; itensImpressos < historicoOperacoes.Length; i++)
                {
                    itensImpressos++;
                    numeroExibicao--;
                    if (i == historicoOperacoes.Length)
                    {
                        i = 0; // reseta
                    }

                    if (historicoOperacoes[i] == null)
                        continue;
                    else
                    {
                        Console.WriteLine($"{(numeroExibicao)}. {historicoOperacoes[i]}");
                    }
                }
            }
        else
            Console.WriteLine("Comando inválido! Digite 'X' para Encerrar, 'H' para Histórico, ou uma operação (+, -, /, *) para calcular.");
    }

    // Loop segundo número em diante
    while (true)
    {
        Console.Write("Digite o próximo número: ");
        segundoInput = Console.ReadLine().ToUpper();
        isSegundoInputNumero = decimal.TryParse(segundoInput, out numeroDois);

        if (isSegundoInputNumero)
            break;
        else if (segundoInput == opcaoDeSaida)
            return;
        else if (segundoInput == opcaoHistorico)
            if (historicoOperacoes.Count(h => h == null) == 10)
                Console.WriteLine("Não há histórico para exibir.");
            else
            {
                int itensImpressos = 0;
                int numeroExibicao = 11;
                for (int i = contadorArray; itensImpressos < historicoOperacoes.Length; i++)
                {
                    itensImpressos++;
                    numeroExibicao--;

                    if (i == historicoOperacoes.Length)
                    {
                        i = 0; // reseta
                    }

                    if (historicoOperacoes[i] == null)
                        continue;
                    else
                    {
                        Console.WriteLine($"{(numeroExibicao)}. {historicoOperacoes[i]}");
                    }
                }
            }
        else
            Console.WriteLine("Comando inválido! Digite 'X' para Encerrar, 'H' para Histórico, ou um número para calcular.");
    }

    switch (operacao)
    {
        case "+":
            resultado = numeroUm + numeroDois;
            break;
        case "-":
            resultado = numeroUm - numeroDois;
            break;
        case "*":
            resultado = numeroUm * numeroDois;
            break;
        case "/":
            if (numeroDois != 0)
            {
                resultado = numeroUm / numeroDois;
            }
            else
            {
                Console.WriteLine("Divisão por zero não é permitido!");
                break;
            }
            break;
        default:
            break;
    }

    // Só exibe o resultado se não for divisão por zero
    if (operacao == "/" && numeroDois == 0)
        continue;
    else
        Console.WriteLine($"Resultado: {resultado}");

    // Grava no histórico (FIFO)
    historicoOperacoes[contadorArray] = $"{numeroUm} {operacao} {numeroDois} = {resultado}";
    contadorArray += 1;
    if (contadorArray >= historicoOperacoes.Length)
        contadorArray = 0;

    // Para manter o encadeamento das operações
    numeroUm = resultado;
}