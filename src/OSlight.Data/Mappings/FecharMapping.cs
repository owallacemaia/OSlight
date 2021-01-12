using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSlight.Business.Models;

namespace OSlight.Data.Mappings
{
    public class FecharMapping : IEntityTypeConfiguration<FecharOS>
    {
        public void Configure(EntityTypeBuilder<FecharOS> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(MAX)");
        }
    }
}
