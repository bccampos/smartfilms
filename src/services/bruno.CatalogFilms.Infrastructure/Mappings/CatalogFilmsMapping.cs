using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bruno.CatalogFilms.Infrastructure.Mappings
{
    public class CatalogFilmsMapping : IEntityTypeConfiguration<Domain.CatalogFilms>
    {
        public void Configure(EntityTypeBuilder<Domain.CatalogFilms> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(c => c.Image)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Rating)
                .IsRequired()
                .HasColumnType("decimal(3,1)");

            builder.ToTable("CatalogFilms");
        }
    }
}