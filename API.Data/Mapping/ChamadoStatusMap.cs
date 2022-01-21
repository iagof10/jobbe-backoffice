using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data.Mappings
{
    public class ChamadoStatusMap : IEntityTypeConfiguration<ChamadoStatus>
    {
        public void Configure(EntityTypeBuilder<ChamadoStatus> builder)
        {
            builder.ToTable("Chamado_Status");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired();

        }
    }
}
