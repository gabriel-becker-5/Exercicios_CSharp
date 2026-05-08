using MySql.Data.MySqlClient;
string connectionString = "server=localhost;database=teste;user=root;password=T3Mp2022!@#";
string sql = "INSERT INTO users (nome, idade, creation_date) VALUES (@nome, @idade, @creation_date)";
bool continuar = true;

using (MySqlConnection conn = new MySqlConnection(connectionString))
{
    conn.Open();
    MySqlCommand cmd = new MySqlCommand(sql, conn);

    while (continuar)
    {
        Console.Write("Informe o nome para cadastro: ");
        string nome = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome inválido.");
            continue;
        }

        Console.Write("Informe a idade: ");
        int idade;
        while (!int.TryParse(Console.ReadLine(), out idade))
        {
            Console.Write("Idade inválida. Digite novamente: ");
        }

        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@nome", nome);
        cmd.Parameters.AddWithValue("@idade", idade);
        cmd.Parameters.AddWithValue("@creation_date", DateTime.Now);
        int linhas = cmd.ExecuteNonQuery();

        Console.WriteLine(linhas > 0 ? "Inserido com sucesso." : "Falha ao inserir.");

        Console.Write("Continuar? S/N: ");
        string resposta = Console.ReadLine();

        if (resposta.ToUpper() != "S")
        {
            continuar = false;
            if (resposta.ToUpper() != "N")
            {
                Console.WriteLine("Opção incorreta! Encerrando programa...");
            }
        }
    }
}