using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Domain.Enum;

namespace API.Domain.Entities
{
    public class Chamado : BaseEntity
    {
        public long IdTipoChamado { get; set; }
        public DateTime DtChamadoAbertura { get; set; }
        public DateTime DtChamadoEncerrado { get; set; }
        public DateTime DtChamadoUltimaAcao { get; set; }
        public long IdChamadoCriticidade { get; set; }
        public long IdChamadoStatus { get; set; }
        public string DescricaoChamado { get; set; }
        public long IdUsuario { get; set; }
    }
}
