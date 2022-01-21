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
    public class ItemChamadoMap : IEntityTypeConfiguration<ItemChamado>
    {
        public void Configure(EntityTypeBuilder<ItemChamado> builder)
        {
            builder.ToTable("Item_Chamado");

            builder.HasKey(x => x.Id);
        }
    }
}
