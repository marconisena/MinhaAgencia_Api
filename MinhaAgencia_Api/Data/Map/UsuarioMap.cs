using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaAgencia_Api.Models;

namespace MinhaAgencia_Api.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Cpf).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(128);
        }
    }
}
