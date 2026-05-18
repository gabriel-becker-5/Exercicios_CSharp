// Criar classe Abstrata chamada 'Forma'
// Metodo abstrato CalcularArea() que retorna double
// Criar classe retangulo com largura e altura
// Crie classe circulo com raio
// Implemente CalcularArea() em cada uma e exiba os resultados

using Aula_13_Poo_Exercicio_3;

Retangulo novoRetangulo = new Retangulo(2.75, 2.75);
Console.Write($"Altura: {novoRetangulo.Altura} * Largura: {novoRetangulo.Largura} = ");
Console.WriteLine(novoRetangulo.CalcularArea());

Circulo novoCirculo = new Circulo(5);
Console.Write($"Raio: {novoCirculo.Raio}² * PI = ");
Console.WriteLine(novoCirculo.CalcularArea());