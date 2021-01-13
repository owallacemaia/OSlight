using Microsoft.EntityFrameworkCore;
using OSlight.Business.Models;
using System.Linq;

namespace OSlight.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions context) : base(context) 
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<AbrirOS> abrirOs { get; set; }
        public DbSet<FecharOS> fecharOs { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(builder);
        }
    }
}
