// Consumir API assíncrona com HttpClient
// Use a API pública: https://jsonplaceholder.typicode.com/
// Crie o método static async Task BuscarPostAsync(int id)
// Use HttpClient para buscar Get /posts/{id}
// Exiba o JSON retornado no console
// Trate HttpRequestException com mensagem clara
// No Main, busque os posts de id 1, 2, e 3 em sequência (um await por vez)

async Task BuscarPostAsync(int id)
{
    using var httpClient = new HttpClient();
    string url = $"https://jsonplaceholder.typicode.com/posts/{id}";

	try
	{
		string json = await httpClient.GetStringAsync(url);
        Console.WriteLine(json);
	}
	catch (HttpRequestException ex)
	{
        Console.WriteLine($"Erro ao Buscar Post: {ex.Message}.");
	}
}

await BuscarPostAsync(100);
await BuscarPostAsync(50);
await BuscarPostAsync(0);