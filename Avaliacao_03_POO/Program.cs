using Avaliacao_03_POO;
int diasLocacao = 0;
bool diasValido = false;

List<Veiculo> veiculos =
[   new Caminhao("Volvo", "FH", 2010, 1099.90m, 25),
    new Caminhao("Scania", "Série R", 2014, 1999.90m, 33),
    new Carro("Citroen", "C3", 2022, 899.90m, 5),
    new Carro("Renault", "Kwid", 2026, 799.90m, 5),
    new Moto("Yamaha", "CG", 2025, 199.90m, 150),
    new Moto("Honda", "Titan", 2024, 304.99m, 250)];

Console.WriteLine("=== Sistema de Gerenciamento de Veículos ===");

foreach (Veiculo veiculo in veiculos)
{
    veiculo.ExibirInformacoes();

    while (!diasValido || diasLocacao <= 0)
    {
        Console.Write("Informe a quantidade de dias para locação: ");
        diasValido = int.TryParse(Console.ReadLine(), out diasLocacao);
    }
    Console.WriteLine($"Orçamento Total para as diárias: {veiculo.CalcularLocacao(diasLocacao):C2}");
    diasValido = false;
    Console.WriteLine();
};