using Aula_MVC_04_Exercicios.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Aula_MVC_04_Exercicios.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos {  get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> EmprestimosLivros { get; set; }
    }
}