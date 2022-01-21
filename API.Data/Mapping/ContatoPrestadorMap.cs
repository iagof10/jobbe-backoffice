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
    public class ContatoPrestadorMap : IEntityTypeConfiguration<ContatoPrestador>
    {
        public void Configure(EntityTypeBuilder<ContatoPrestador> builder)
        {
            builder.ToTable("Contato_Prestador");

            builder.HasKey(x => x.Id);
        }
    }
}
