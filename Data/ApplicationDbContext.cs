using Microsoft.EntityFrameworkCore;
using Mottu.Patio.API.Models;

namespace Mottu.Patio.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Moto> Motos { get; set; }
        public DbSet<Filial> Filiais { get; set; }
        public DbSet<Localizacao> Localizacoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Moto>().ToTable("T_MOTTU_MOTOS");
            modelBuilder.Entity<Filial>().ToTable("T_MOTTU_FILIAIS");
            modelBuilder.Entity<Localizacao>().ToTable("T_MOTTU_LOCALIZACOES");
            modelBuilder.Entity<Usuario>().ToTable("T_MOTTU_USUARIO");
        }
    }
}