// Objetivo: Usar Task.WhenAll para tarefas em paralelo
// Crie o método static async Task<string> SimularDownloadAsync(string arquivo)
// Simula um delay aleatório entre 500ms e 2000ms
// Retorna: '{arquivo} baixado!'
// No Main:
// Crie 4 tasks para arquivos: 'relatorio.pdf', 'foto.jpg', 'dados.csv', 'config.json'
// Use Task.WhenAll para executá-las em paralelo
// Meça o tempo total com Stopwatch e exiba o resultado

using System.Diagnostics;
const int DELAY_MINIMO_MS = 500;
const int DELAY_MAXIMO_MS = 2001;
Stopwatch cronometro = Stopwatch.StartNew();
Random numeroAleatorio = new Random();

async Task<string> SimularDownloadAsync(string arquivo)
{    
    var delay = numeroAleatorio.Next(DELAY_MINIMO_MS, DELAY_MAXIMO_MS);
    // Console.WriteLine("Delay sorteado: " + delay + " milissegundos.");
    await Task.Delay(delay);
    return $"{arquivo} baixado!";
}

var tarefa1 = SimularDownloadAsync("relatorio.pdf");
var tarefa2 = SimularDownloadAsync("foto.jpg");
var tarefa3 = SimularDownloadAsync("dados.csv");
var tarefa4 = SimularDownloadAsync("config.json");

string[] resultados = await Task.WhenAll(tarefa1, tarefa2, tarefa3, tarefa4);

foreach (var resultado in resultados)
    Console.WriteLine(resultado);

cronometro.Stop();
Console.WriteLine($"Tempo Total de execução: " + cronometro.Elapsed.TotalSeconds + " segundos.");