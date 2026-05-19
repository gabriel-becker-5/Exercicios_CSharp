// Exercício 1 - Hierarquia de Veículos
// Classe Veículo com método virtual Mover() que exibe 'Veículo se movendo...'
// Classe Carro que sobrescreve Mover() -> 'Carro acelerando na estrada'
// Classe Barco que sobrescreve Mover() -> 'Barco navegando na água'
// Classe Aviao que sobrescreve Mover() -> 'Avião voando no céu'
// Crie objetos de cada tipo, guarde em uma List<Veiculo> e chame Mover() em cada objeto

using Aula_14_Poo_Exercicio_1;

List<Veiculo> veiculos =
[
    new Veiculo(),
    new Carro(),
    new Barco(),
    new Aviao()
];

foreach (Veiculo veiculo in veiculos)
{
    Console.WriteLine(veiculo.Mover());
};