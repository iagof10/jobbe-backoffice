using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Entities
{
    public class SubCategoriaPrestadorDto : BaseEntity
    {
        public long Id { get; set; }
        public long SubCategoriaId { get; set; }
    }
}
