using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data.Mappings
{
    public class TelefoneUsuarioMap : IEntityTypeConfiguration<TelefoneUsuario>
    {
        public void Configure(EntityTypeBuilder<TelefoneUsuario> builder)
        {
            builder.ToTable("Telefone");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.NumeroTelefone).IsRequired();
            builder.Property(x => x.UsuarioId).IsRequired();

        }
    }
}
