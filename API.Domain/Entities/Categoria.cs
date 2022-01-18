using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Entities
{
    public class Categoria : BaseEntity
    {
        public string Descricao { get; set; }
        public string ImagemUrl { get; set; }
    }
}
