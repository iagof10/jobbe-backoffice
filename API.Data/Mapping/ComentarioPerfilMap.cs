using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data.Mappings
{
    public class ComentarioPerfilMap : IEntityTypeConfiguration<ComentarioPerfil>
    {
        public void Configure(EntityTypeBuilder<ComentarioPerfil> builder)
        {
            builder.ToTable("ComentarioPerfil");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Comentario).IsRequired();

        }
    }
}
