using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Domain.DTOs.TipoChamado
{
    public class TipoChamadoDto
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
    }
}
