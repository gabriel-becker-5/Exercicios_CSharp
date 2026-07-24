using Aula_REST_API_01_Exercicios.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula_REST_API_01_Exercicios.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
    }
}