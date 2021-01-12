using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSlight.Business.Models;

namespace OSlight.Data.Mappings
{
    public class AbrirOSMapping : IEntityTypeConfiguration<AbrirOS>
    {
        public void Configure(EntityTypeBuilder<AbrirOS> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Titulo)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.NomeReclamante)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(MAX)");

            builder.Property(p => p.NumeroPoste)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasOne(p => p.Endereco)
                .WithOne(p => p.AbrirOS);

            builder.HasOne(p => p.FecharOS)
                .WithOne(p => p.AbrirOS)
                .HasForeignKey<FecharOS>(p => p.AbrirOSId);

            builder.ToTable("AbrirOS");
        }
    }
}
