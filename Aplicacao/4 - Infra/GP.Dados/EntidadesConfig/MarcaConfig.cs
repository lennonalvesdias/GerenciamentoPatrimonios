using GP.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GP.Dados.EntidadesConfig
{
    public class MarcaConfig : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.ToTable("Marcas");

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
