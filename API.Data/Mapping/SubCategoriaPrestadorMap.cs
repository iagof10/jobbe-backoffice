using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data.Mapping
{
    public class SubCategoriaPrestadorMap : IEntityTypeConfiguration<SubCategoriaPrestador>
    {
        public void Configure(EntityTypeBuilder<SubCategoriaPrestador> builder)
        {
            builder.ToTable("Sub_Categoria_Usuario");

            builder.HasKey(x => x.Id);
        }
    }
}
