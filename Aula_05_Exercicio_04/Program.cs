// Crie um programa que peça ao usuário uma senha númerica
// Repita a solicitação até que a senha digitada seja igual a 1234
// Quando acertar, exiba a mensagem "Acesso liberado"

int senhaUsuario;
string inputUsuario;
int senhaDoSistema = 1234;

do
{
    Console.Write("Informe a Senha (apenas números): ");
    inputUsuario = Console.ReadLine();
    int.TryParse(inputUsuario, out senhaUsuario);

    if (senhaUsuario == senhaDoSistema)
    {
        Console.WriteLine("Acesso liberado!");
    }
}
while (senhaUsuario != senhaDoSistema);