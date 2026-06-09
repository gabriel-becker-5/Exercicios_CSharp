// Objetivo: Criar e chamar um método async básico
// Crie um método assíncrono static async Task SaudarAsync(string nome) que:
// Aguarda 1 segundo com Task.Delay(1000)
// Exibe: 'Olá, {nome}! Bem-vindo ao async/await.'
// No Program.cs, chame o método com await para três nomes diferentes.
// Observe que o programa espera cada saudação antes de avançar.

async Task SaudarAsync(string nome)
{
    await Task.Delay(1000);
    Console.WriteLine($"Olá, {nome}! Bem-vindo ao async/await.");
}

await SaudarAsync("Gabriel");
await SaudarAsync("Alexandre");
await SaudarAsync("Cássia");