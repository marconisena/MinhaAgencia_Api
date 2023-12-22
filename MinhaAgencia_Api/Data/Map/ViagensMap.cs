using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaAgencia_Api.Models;

namespace MinhaAgencia_Api.Data.Map
{
    public class ViagensMap : IEntityTypeConfiguration<ViagensModel>
    {
        public void Configure(EntityTypeBuilder<ViagensModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Destino).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.UsuarioId);
            builder.HasOne(x => x.Usuario);

        }
    }
}
