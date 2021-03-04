using Desafio_Backend_Novaweb.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Backend_Novaweb.Data
{
    public class ContatoContext : DbContext
    {
        public ContatoContext(DbContextOptions<ContatoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Contato> Contatos { get; set; }
    }
}
