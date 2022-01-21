﻿using System;
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
        public long NroChamado { get; set; }
        public long IdTipoChamado { get; set; }
        public DateTime DtChamadoAbertura { get; set; }
        public DateTime DtChamadoEncerrado { get; set; }
        public DateTime DtChamadoUltimaAcao { get; set; }
        public string IdChamadoCriticidade { get; set; }
        public string IdChamadoStatus { get; set; }
        public string DescricaoChamado { get; set; }
        public long IdUsuario { get; set; }
    }
}
