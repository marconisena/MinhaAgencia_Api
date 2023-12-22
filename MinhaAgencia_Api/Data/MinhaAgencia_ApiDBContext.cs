using Microsoft.EntityFrameworkCore;
using MinhaAgencia_Api.Data.Map;
using MinhaAgencia_Api.Models;

namespace MinhaAgencia_Api.Data
{
    public class MinhaAgencia_ApiDBContext : DbContext
    {
        public MinhaAgencia_ApiDBContext(DbContextOptions<MinhaAgencia_ApiDBContext> options)
     : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; } = null!;
        public DbSet<ViagensModel> Viagens{ get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ViagensMap());
            base.OnModelCreating(modelBuilder);
        }
      
    }
}
