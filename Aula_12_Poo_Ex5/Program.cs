// Crie classe carro com: marca, modelo, velocidade atual
// Regras:
// velocidade não pode ser negativa
// criar método para acelerar
// criar método para frear
// exibir velocidade atual

using Aula_12_Poo_Ex5;

Carro carro1 = new Carro();
carro1.Marca = "Renault";
carro1.Modelo = "Kwid";
carro1.ApresentarDados();

carro1.ApresentarDados();

carro1.Acelerar(-100);

carro1.ApresentarDados();

carro1.Frear(102);

carro1.ApresentarDados();

carro1.Acelerar(10);

carro1.ApresentarDados();