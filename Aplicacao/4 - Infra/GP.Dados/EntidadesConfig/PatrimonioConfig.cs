using GP.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GP.Dados.EntidadesConfig
{
    public class PatrimonioConfig : IEntityTypeConfiguration<Patrimonio>
    {
        public void Configure(EntityTypeBuilder<Patrimonio> builder)
        {
            builder.ToTable("Patrimonios");

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.MarcaId)
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(300)")
                .HasMaxLength(300);

            builder.Property(c => c.NumeroTombo)
                .HasColumnType("varchar(36)")
                .HasMaxLength(36);
        }
    }
}
