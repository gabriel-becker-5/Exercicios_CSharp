// Ex 1 - Implemente a Action que lista todos os alunos cadastrados no banco
// - Injete o AppDbContext no AlunosController
// - Implemente Index() usando ToListAsync()
// - Crie a view correspondente exibindo alunos em uma tabela HTML
// - Teste acessando /Alunos no navegador

// Ex 2 - Implemente a operação Create completa, com formulário e gravação
// - Crie a view Criar.cshtml com um formulário (campos Nome, Email e DataNascimento)
// - Implemente a Action [HttpPost] Criar(Aluno aluno)
// - Use Add() + SaveChangesAsync() para gravar
// - Após salvar, redirecione para Index()

// Ex 3 - Implemente a operação Update completa, carregando os dados existentes
// - Crie a Action [HttpGet] Editar(int id) que busca o aluno com FindAsync
// - Crie a view Editar.cshtml pré-preenchida com os dados atuais
// - Crie a Action [HttpPost] Editar(int id, Aluno dados) que atualiza e salva
// - Teste editando um aluno já cadastrado

// Ex 4 - Implemente a operação Delete com tela de confirmação
// - Crie a Action [HttpGet] Excluir(int id) que busca e exibe os dados para confirmação
// - Crie a view Excluir.cshtml mostrando os dados e um botão 'Confirmar Exclusão?'
// - Crie a Action [HttpPost] ExcluirConfirmado(int id) que remove e salva
// - Teste o fluxo completo de exclusão

// Ex 5 - Implemente um campo de busca simples na listagem de alunos.
// - Adicione um campo de busca (input + botão) na View index
// - Crie a action Index(string busca) que recebe o termo via query string
// - Use Where() com Contains() para filtrar pelo nome
// - Se a busca estiver vazia, retorne todos os alunos normalmente

// Ex 6 - CRUD Completo de Cursos - Replique o CRUD para a entidade Curso
// - Implemente Index, Criar, Editar e Exluir para Curso (reaproveite o Model da Aula 04)
// - Adicione validação simples: CargaHoraria deve ser maior que zero
// - Na listagem, ordene os cursos por CargaHoraria (do maior para o menor)
// - Adicione um contador no topo da página: "Total de cursos cadastrados: X"
// - Use TempData para exibir uma mensagem de sucesso após criar/editar/excluir

using Aula_MVC_04_Exercicios.Data;
using Aula_MVC_04_Exercicios.Interfaces;
using Aula_MVC_04_Exercicios.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseMySQL(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDataHoraService, DataHoraService>();
builder.Services.AddScoped<ICalculadoraCargaHorariaService, CalculadoraCargaHorariaService>();

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