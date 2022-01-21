using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Entities
{
    public class ContatoPrestador : BaseEntity
    {
        public long IdPrestador { get; set; }
        public DateTime DataExclusao { get; set; }
    }
}
