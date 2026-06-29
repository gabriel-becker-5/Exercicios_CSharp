/* Ex 1 - Crie uma view que exibe uma saudação personalizada usando ViewBag
   - No HomeController, crie a Action Saudacao(string nome)
   - Dentro da Action, atribua ViewBag.Nome = nome
   - Crie a view correspondente exibindo: "Olá, @ViewBag.Nome!"
   - Use também @DateTime.Now para mostrar a data atual na página  

   Ex 2 - Crie uma view fortemente tipada que exibe uma lista de tarefas
   - Crie a classe Models/Tarefa.cs com propriedades Titulo e Concluida
   - No Controller, crie uma List<Tarefa> com pelo menos 4 itens
   - Envie a lista para a View com return View(lista)
   - Na View, declare @model List<Tarefa> e use @foreach para listar
   - Exiba um emoji de concluído ou não, conforme cada tarefa

   Ex 3 - Customize o _Layout.cshtml com identidade visual própria
   - Abra Views/Shared/_Layout.cshtml
   - Altere o título do site no <title> e no menu superior
   - Adicione um rodapé customizada com seu nome
   - Confirme que todas as páginas do projeto herdam essa mudança automaticamente

   Ex 4 - Crie uma Partial View para exibir produtos de forma consistente.
   - Crie Models/Produto.cs com Nome, Preco e Categoria
   - Crie Views/Shared/_CardProduto.cshtml fortemente tipada para Produto
   - No Controller, crie uma lista de 5 produtos variados
   - Na View principal, use @foreach + <partial> para renderizar cada card

   Ex 5 - Use lógica condicional Razor para exibir mensagens diferentes
   - Crie a Action Estoque(int quantidade) recebendo um número via query string
   - Envie a quantidade para a View usando ViewBag ou Model
   - Na View, use @if/else para exibir: 'Em estoque' (>0) ou 'Esgotado' (=0)
   - Se quantidade <5, exiba também um aviso 'Ultimas unidades!'

   Desafio - Catálogo de Produtos Completo
   - Combine Model, Partial View e Layout em uma página de catálogo funcional
   - Crie uma lista com pelo menos 6 produtos com Nome, Preco e Categoria
   - Use a Partial View _CardProduto.cshtml criada no exercício 4
   - Agrupe os produtos por Categoria usando @foreach aninhado ou GroupBy do LINQ
   - Exiba o total de produtos e o valor total do catálogo no topo da página
   - Customize o CSS para que os cards fiquem organizados em grade  */

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
