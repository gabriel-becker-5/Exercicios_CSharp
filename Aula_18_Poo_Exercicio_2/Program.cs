// Objetivo: Usar Task<T> para retornar valor assíncrono
// Crie o método static async Task<double> CalcularMediaAsync(List<int> numeros)
// Simule processamento com Task.Delay(500)
// Retorne a média dos números
// Crie uma lista com 5 números de sua escolha
// Chame o método com await e exiba: A lista original e a média calculada

async Task<double> CalcularMediaAsync(List<int> numeros)
{
    await Task.Delay(500);
    return numeros.Average();
}

List<int> numerosEscolhidos = [10, 6542, 43, -4654, 23115];

Console.WriteLine($"Números escolhidos: {string.Join(", ", numerosEscolhidos)}");

double media = await CalcularMediaAsync(numerosEscolhidos);

Console.WriteLine($"Média dos números: {media}");