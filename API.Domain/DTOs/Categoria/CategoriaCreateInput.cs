using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.DTOs.Categoria
{
    public class CategoriaCreateInput
    {
        public string Descricao { get; set; }
        public string ImagemUrl { get; set; }
    }
}
