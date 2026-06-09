// Dashboard Assíncrono com múltiplas APIs
// Use a API pública jsonplaceholder.typicode.com para construir um mini-dashboard
// Use Task.WhenAll para buscar em paralelo:
// 3 posts (Get /posts/1, /posts/2, /posts/3)
// 3 usuarios (Get /users/1, /users/2, /users/3)
// Após receber todos os dados:
// Exiba o título de cada post e o nome de cada usuário
// Meça e exiba o tempo total de todas as requisições
// Trate erros individuais sem cancelar as outras buscas

using System.Diagnostics;
using System.Text.Json;
Stopwatch cronometro = Stopwatch.StartNew();
using HttpClient httpClient = new HttpClient();

async Task BuscarPostAsync(int postId)
{
    string url = $"https://jsonplaceholder.typicode.com/posts/{postId}";

	try
	{
		string jsonString = await httpClient.GetStringAsync(url);

        using (JsonDocument jsonDocument = JsonDocument.Parse(jsonString))
        {
            JsonElement root = jsonDocument.RootElement;
            string tituloPost = root.GetProperty("title").GetString();
            Console.WriteLine($"Título do Post: {tituloPost}.");
        }
    }
	catch (Exception ex)
	{
        Console.WriteLine($"Erro inesperado ao buscar Post: {ex.Message}.");		
	}
}

async Task BuscarUserAsync(int userId)
{
    string url = $"https://jsonplaceholder.typicode.com/users/{userId}";

    try
    {
        string jsonString = await httpClient.GetStringAsync(url);

        using (JsonDocument jsonDocument = JsonDocument.Parse(jsonString))
        {
            JsonElement root = jsonDocument.RootElement;
            string nomeUsuario = root.GetProperty("name").GetString();
            Console.WriteLine($"Nome do Usuário: {nomeUsuario}.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro inesperado ao buscar Usuário: {ex.Message}.");
    }
}

var tarefa1 = BuscarPostAsync(0);
var tarefa2 = BuscarPostAsync(10);
var tarefa3 = BuscarPostAsync(20);
var tarefa4 = BuscarUserAsync(0);
var tarefa5 = BuscarUserAsync(1);
var tarefa6 = BuscarUserAsync(2);

await Task.WhenAll(tarefa1, tarefa2, tarefa3, tarefa4, tarefa5, tarefa6);

cronometro.Stop();
Console.WriteLine($"Tempo total de execução: {cronometro.Elapsed.TotalSeconds} segundos.");