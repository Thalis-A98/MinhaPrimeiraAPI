using Microsoft.EntityFrameworkCore;
using MinhaPrimeiraAPI.Models;

namespace MinhaPrimeiraAPI.Data
{
    public class SistemadeCadastroDBContext : DbContext
    {
        public SistemadeCadastroDBContext(DbContextOptions<SistemadeCadastroDBContext> options):base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
