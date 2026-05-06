using Aula_10_Poo;
int inputMenu;

Console.WriteLine("Exercícios POO - Aula 10");
Console.WriteLine("1. Carro");
Console.WriteLine("2. Pessoa");
Console.WriteLine("3. Produto");
Console.WriteLine("4. ContaBancaria");
Console.WriteLine("5. Aluno");

Console.Write("Digite a opção para acessar: ");
inputMenu = int.Parse(Console.ReadLine());

switch (inputMenu)
{
    case 1:
        Carro carro1 = new Carro()
        {
            Marca = "Renault",
            Modelo = "Kwid"
        };
        carro1.ExibirDadosCarro();
        break;

    case 2:
        Pessoa pessoa1 = new Pessoa()
        {
            Nome = "Gabriel",
            Idade = 31
        };
        pessoa1.ExibirDadosPessoa();
        break;

    case 3:
        Produto produto1 = new Produto()
        {
            Nome = "Ventilador 220v",
            Preco = 199.99m
        };
        Produto produto2 = new Produto()
        {
            Nome = "Ventilador 110v",
            Preco = 209.99m
        };
        produto1.ExibirDadosProduto();
        produto2.ExibirDadosProduto();
        break;

    case 4:
        ContaBancaria conta1 = new ContaBancaria()
        {
            Titular = "Gabriel",
            Saldo = 1005.95m
        };
        conta1.ExibirSaldo();
        break;

    case 5:
        Aluno aluno1 = new Aluno()
        {
            Nome = "Gabriel",
            Nota = 7.5m
        };
        if (aluno1.EhAprovado())
        {
            Console.WriteLine("Aprovado");
        }
        else
        {
            Console.WriteLine("Reprovado");
        }
        break;
}