using Microsoft.EntityFrameworkCore;
using ListaContatos.Domain.Model;
using ListaContatos.Data.Map;

namespace ListaContatos.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Contato> Contato { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-51NBV2R; Database=ListaContatos; Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}