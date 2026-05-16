// Crie classe Veículo com atributos marca e modelo
// Método ExibirInfo() que exibe marca e modelo
// Crie a classe Carro que herda de Veiculo
// Adicione a propriedade NumeroDePortas
// Crie um Objeto Carro e exiba todas as infos.

using Aula_13_Poo;

Carro carro1 = new Carro();

carro1.marca = "Toyota";
carro1.modelo = "Prius";
carro1.NumeroDePortas = 4;

carro1.ExibirInfo();