using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.DTOs.ContatoPrestador
{
    public class ContatoPrestadorDto
    {
        public long Id { get; set; }
        public long IdPrestador { get; set; }
        public DateTime DataExclusao { get; set; }
    }
}
