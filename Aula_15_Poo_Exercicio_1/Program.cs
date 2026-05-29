// Criar e implementar uma interface
// Crie a interface IFormaGeometrica com:
// double CalcularArea()
// double CalcularPerimetro()
// Implemente nas classes retangulo e circulo
// Exiba área e perímetro de cada forma

using Aula_15_Poo_Exercicio_1;

List<IFormaGeometrica> formasGeometricas =
[
    new Circulo(5),
    new Circulo(10),
    new Circulo(15),
    new Retangulo(5,5),
    new Retangulo(10,10),
    new Retangulo(15,15)
];

foreach (IFormaGeometrica formaGeometrica in formasGeometricas)
{
    formaGeometrica.ApresentarDados();
    Console.WriteLine();
};