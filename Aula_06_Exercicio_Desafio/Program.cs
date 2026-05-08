// armazene 6 notas de um aluno em um array
// calcule a média
// exiba: aprovado (>=7), recuperação (>=5), reprovado (<5)

int[] notas = new int[6];

for (int i = 0; i < notas.Length; i++)
{
    Console.Write("Digite a nota " + (i + 1) + ": ");
    notas[i] = int.Parse(Console.ReadLine());
    while (notas[i] < 0 || notas[i] > 10)

    {
        Console.WriteLine("Digite uma nota válida! Entre 0 e 10."); Console.Write("Digite a nota " + (i + 1) + ": "); notas[i] = int.Parse(Console.ReadLine());
    }
}
Console.WriteLine("Média Final do Aluno: " + notas.Average()); if (notas.Average() >= 7) { Console.WriteLine("Aprovado"); }
else if (notas.Average() >= 5)
{
    Console.WriteLine("Recuperação");
}
else
{
    Console.WriteLine("Reprovado");
}