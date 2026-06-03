// Sistema bancária com exceções customizadas
// Crie a classe ContaBancaria com Titular, Saldo e os métodos Depositar e Sacar
// Crie as exceções customizadas:
// - SaldoInsuficienteException (informa saldo atual e valor solicitado)
// - ValorInvalidoException (para depósitos ou saques negativos ou zero)
// No Main:
// - Simule 5 operações variadas (depósitos e saques válidos e inválidos)
// - Trate cada exceção exibindo mensagens claras para o usuário
// - Use finally para sempre exibir o saldo atual após cada operação

using Aula_17_Poo_Desafio;

List<ContaBancaria> contasBancarias = new List<ContaBancaria>
{
    new ContaBancaria("Gabriel", 100.55m),
    new ContaBancaria("Pedro", -1)
};

Console.WriteLine("===== Bem vindo ao Banco Entra 21 =====");

foreach (ContaBancaria contaBancaria in contasBancarias)
{
    try
    {
        Console.WriteLine($"Nome do Titular: {contaBancaria.Titular}");
        contaBancaria.Depositar(5);
        contaBancaria.Sacar(1000m);
    }
    catch (SaldoInsuficienteException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (ValorInvalidoException ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        Console.WriteLine($"Saldo Atual: {contaBancaria.Saldo:C2}");
        Console.WriteLine("");
    }
}