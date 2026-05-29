// Identificar Code Smells
// Analise o trecho abaixo e liste os problemas
// public void F(int x, int y, int z, int w)
// { // calcula tudo aqui
// int r = x+y; int r2 = x+y; Console.WriteLine(r+r2+z+w);}
// Liste os smells encontrados e reescreva o método corrigido



// Code Smells Identificados:
// 1. Nome das variáveis de dificil identificação: int x, y, z, w
// 2. Cálculo repetido: x+y
// 3. Comentário que não explica a operação realizada
// 4. Muitas responsabilidades para um método: Calcula e exibe o resultado

// Código refatorado sem Code Smells:
public int CalcularResultado(int primeiroValor, int segundoValor, int terceiroValor, int quartoValor)
{
    int somaBase = primeiroValor + segundoValor;
    return (somaBase * 2) + terceiroValor + quartoValor;
}