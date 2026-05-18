// Crie uma classe abstrata Funcionario
// Propriedade Nome e método abstrato CalcularSalario()
// Classe CLT: recebe salário fixo mensal
// Classe PJ: recebe valor por hora e horas trabalhadas
// Exiba o salário calculado de cada tipo de funcionário

using Aula_13_Poo_Exercicio_4;

CLT funcionarioCLT1 = new CLT("Paulo", 2450.75m);
Console.WriteLine($"Funcionário: {funcionarioCLT1.Nome}. Salário à receber: R$ {funcionarioCLT1.CalcularSalario()}");

PJ funcionarioPJ1 = new PJ("Gabriel", 14.5m, 190);
Console.WriteLine($"Funcionário: {funcionarioPJ1.Nome}. Salário à receber: R$ {funcionarioPJ1.CalcularSalario()}");