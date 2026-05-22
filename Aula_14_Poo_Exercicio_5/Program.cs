// Exercício 5 - Aplicação completa com polimorfismo
// Crie um sistema de funcionários com cálculo de bônus:
// Classe base Funcionario com Nome, Salario e método virtual CalcularBonus()
// Gerente: bônus de 30% do salário
// Desenvolvedor: bônus de 20% do salário
// Estagiário: sem bônus (retorna 0)
// Crie uma List<Funcionario> com os três tipos
// Exiba nome, salário, bônus e total (salário + bônus) de cada um

using Aula_14_Poo_Exercicio_5;

List<Funcionario> funcionarios =
[
    new Desenvolvedor("Gabriel Dev", 1000),
    new Estagiario("Gabriel Est", 1000),
    new Gerente("Gabriel Ger", 1000)
];

foreach (Funcionario funcionario in funcionarios)
{
    Console.WriteLine(
        $"Nome: {funcionario.Nome} | Salário: {funcionario.Salario:C} | Bônus: {funcionario.CalcularBonus():C} | Total: {funcionario.SalarioTotal():C}"
    );
}