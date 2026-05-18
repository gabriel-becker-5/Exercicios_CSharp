// Fluxograma Analisar Idade

Console.Write("Informe sua Idade: ");

int idadeUsuario = int.Parse(Console.ReadLine());

if (idadeUsuario <= 0)
{
    Console.WriteLine("Idade incorreta!");
}
else if (idadeUsuario < 18)
{
    Console.WriteLine("Menor de Idade");
}
else if (idadeUsuario >= 65)
{
    Console.WriteLine("Aposentado");
}
else
{
    Console.WriteLine("Maior de Idade");
}