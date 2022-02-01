using API.Domain.DTOs.ChamadoCriticidade;
using API.Domain.DTOs.ChamadoStatus;
using API.Domain.DTOs.TipoChamado;
using API.Domain.DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Domain.DTOs.Chamado
{
    public class ChamadoDto
    {
        public long Id { get; set; }
        public long IdTipoChamado { get; set; }
        public DateTime DtChamadoAbertura { get; set; }
        public DateTime DtChamadoEncerrado { get; set; }
        public DateTime DtChamadoUltimaAcao { get; set; }
        public long IdChamadoCriticidade { get; set; }
        public long IdChamadoStatus { get; set; }
        public string DescricaoChamado { get; set; }
        public long IdUsuario { get; set; }
        public virtual ChamadoStatusDto ChamadoStatus { get; set; }
        public virtual ChamadoCriticidadeDto ChamadoCriticidade { get; set; }
        public virtual TipoChamadoDto TipoChamado { get; set; }
        public virtual UsuarioDto UsuarioChamado { get; set; }

    }
}
