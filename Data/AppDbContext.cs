using Microsoft.EntityFrameworkCore;
using ProjetoEstoqueASS.Models;

namespace ProjetoEstoqueASS.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Item> Itens { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasKey(i => i.Codigo); // Chave primária é o Código

            modelBuilder.Entity<Item>()
                .Property(i => i.Codigo)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Item>()
                .Property(i => i.Nome)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}