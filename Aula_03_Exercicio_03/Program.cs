// Crie um programa que: peça o salário mensal
// Calcule o salário anual (salário x 12)
// Exiba o resultado

Console.Write("Informe o salário mensal: R$ ");
float salarioMensal = float.Parse(Console.ReadLine());

float salarioAnual = salarioMensal * 12;
Console.Write("O salário anual é: R$ " + salarioAnual);