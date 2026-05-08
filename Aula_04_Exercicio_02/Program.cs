// Login simplificado

string loginBD = "gabriel05";
string passwordBD = "PWpadrao123";
string nomeReduzidoCliente = "Gabriel Alexandre";
double saldoContaCorrente = 1500.55d;
const int LIMITE_TENTATIVAS = 3;

Console.WriteLine("Olá! Seja-bem vindo ao banco Entra21. Insira o número da sua Conta e Senha entrar.");

// Login Existe? + Até 3 tentativas incorretas
string loginInput = Console.ReadLine();
int tentativasLoginFalhado = 0;

do
{
    Console.Write("Número da Conta: ");
}
while (loginInput != loginBD && tentativasLoginFalhado < LIMITE_TENTATIVAS);



while (loginInput != loginBD && tentativasLoginFalhado < LIMITE_TENTATIVAS) ;
{
    Console.WriteLine("Conta inexistente! " + (LIMITE_TENTATIVAS - tentativasLoginFalhado) + " tentativa(s) restante(s).");
    Console.Write("Número da Conta: ");
    loginInput = Console.ReadLine();
    if (tentativasLoginFalhado >= LIMITE_TENTATIVAS)
    {
        Console.WriteLine("Conta bloqueada por excesso de tentativas, contate o suporte.");
        return;
    }
    tentativasLoginFalhado++;
}

// Senha Correta? + Até 3 tentativas incorretas
Console.Write("Senha: ");
string passwordInput = Console.ReadLine();
int tentativasSenhaIncorreta = 0;

while (passwordInput != passwordBD && tentativasSenhaIncorreta < LIMITE_TENTATIVAS)
{
    Console.WriteLine("Senha incorreta! " + (LIMITE_TENTATIVAS - tentativasSenhaIncorreta) + " tentativa(s) restante(s).");
    Console.Write("Senha: ");
    loginInput = Console.ReadLine();
    if (tentativasSenhaIncorreta >= LIMITE_TENTATIVAS)
    {
        Console.WriteLine("Contate o suporte para fazer o reset da senha.");
        return;
    }
    tentativasSenhaIncorreta++;
}

Console.WriteLine("Bem vindo, " + nomeReduzidoCliente + ".");
Console.WriteLine("Saldo Conta Corrente: R$ " + saldoContaCorrente + ".");