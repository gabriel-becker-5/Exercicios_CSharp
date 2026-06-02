// Criar e lançar exceção customizada
// Crie a exceção customizada IdadeInvalidaException
// Crie o método CadastrarPessoa(string nome, int idade) que:
// 1. Lança IdadeInvalidaException se idade < 0 ou > 150
// 2. Exibe os dados se válido
// No Main, teste com idades válidas e inválidas
// Capture e exiba a mensagem da exceção customizada.

using Aula_17_Poo_Exercicio_4;

void CadastrarPessoa(string nome, int idade)
{
    
    Console.WriteLine($"");

    throw new IdadeInvalidaException();
};