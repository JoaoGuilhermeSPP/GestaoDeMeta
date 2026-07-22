using GestaoFinanceiro.Model;
using Microsoft.EntityFrameworkCore;

namespace GestaoFinanceiro.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } //Construtor

    public DbSet<Entradas> Entradas {  get; set; }
    public DbSet<Despesas> Despesas { get; set; }

    public DbSet<Guardado> Guardadas { get; set; }

    public DbSet<Destinos> Destinos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guardado>()
                .HasOne(g => g.Destino)
                .WithMany(d => d.Guardados)
                .HasForeignKey(g => g.IdDestino);
        }
    }
}
