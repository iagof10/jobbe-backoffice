using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Entities
{
    public class SubCategoria : BaseEntity
    {
        public string Descricao { get; set; }
        public long CategoriaId { get; set; }
        public string ImagemUrl { get; set; }
    }
}
