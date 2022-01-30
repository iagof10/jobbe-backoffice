using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.DTOs.Chamado
{
    public class ChamadoCreateInput
    {
        public long IdTipoChamado { get; set; }
        public DateTime DtChamadoAbertura { get; set; }
        public DateTime DtChamadoUltimaAcao { get; set; }
        public string IdChamadoCriticidade { get; set; }
        public string IdChamadoStatus { get; set; }
        public string DescricaoChamado { get; set; }
        public long IdUsuario { get; set; }
    }
}
