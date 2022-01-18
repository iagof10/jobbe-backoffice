using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data.Mappings
{
    public class SubCategoriaMap : IEntityTypeConfiguration<SubCategoria>
    {
        public void Configure(EntityTypeBuilder<SubCategoria> builder)
        {
            builder.ToTable("Sub_Categoria");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired();

        }
    }
}
