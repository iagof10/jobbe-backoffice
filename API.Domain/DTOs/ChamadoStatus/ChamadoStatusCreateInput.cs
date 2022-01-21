using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.DTOs.ChamadoStatus
{
    public class ChamadoStatusCreateInput
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
    }
}
