// tenha um array com 5 nomes
// peça um nome ao usuário
// verifique se o nome existe no array
// exiba "encontrado" ou "não encontrado"

string[] nomesIniciais = ["Gabriel", "Cássia", "Pedro", "Andreia", "José"];
string nomeInformadoUsuario;
bool nomeEncontrado = false;

Console.Write("Informe um Nome: ");
nomeInformadoUsuario = Console.ReadLine();

for (int i = 0; i < nomesIniciais.Length; i++)
{
    if (nomesIniciais[i].ToLower() == nomeInformadoUsuario.ToLower())
    {
        nomeEncontrado = true;
    }
}

if (nomeEncontrado)
{
    Console.WriteLine("Encontrado!");
}
else
{
    Console.WriteLine("Não encontrado!");
}