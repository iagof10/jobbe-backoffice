using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Entities
{
    public class ChamadoCriticidade : BaseEntity
    {
        public string Descricao { get; set; }
        public long Prazo { get; set; }
    }
}
