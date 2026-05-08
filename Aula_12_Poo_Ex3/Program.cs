// Criar classe Conta
// Deve possuir saldo privado
// Permita depositar valores positivos
// Permita sacar apenas se houver saldo
// Exibir saldo atual

using Aula_12_Poo_Ex3;

Conta conta1 = new Conta();

Console.WriteLine(conta1.Saldo);

conta1.Depositar(-5);

Console.WriteLine(conta1.Saldo);

conta1.Sacar(95);

Console.WriteLine(conta1.Saldo);