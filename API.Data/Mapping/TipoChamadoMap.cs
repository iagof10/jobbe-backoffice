using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data.Mappings
{
    public class TipoChamadoMap : IEntityTypeConfiguration<TipoChamado>
    {
        public void Configure(EntityTypeBuilder<TipoChamado> builder)
        {
            builder.ToTable("Tipo_Chamado");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired();

        }
    }
}
