using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.DTOs.ChamadoCriticidade
{
    public class ChamadoCriticidadeCreateInput
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public long Prazo { get; set; }
    }
}
