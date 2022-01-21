using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data.Mappings
{
    public class ChamadoCriticidadeMap : IEntityTypeConfiguration<ChamadoCriticidade>
    {
        public void Configure(EntityTypeBuilder<ChamadoCriticidade> builder)
        {
            builder.ToTable("Chamado_Criticidade");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired();

        }
    }
}
