using Microsoft.EntityFrameworkCore;
using OSlight.Business.Models;

namespace OSlight.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions context) : base(context) { }

        public DbSet<AbrirOS> abrirOs { get; set; }
        public DbSet<FecharOS> fecharOs { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
