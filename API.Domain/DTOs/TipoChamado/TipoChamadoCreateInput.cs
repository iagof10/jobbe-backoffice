﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.DTOs.TipoChamado
{
    public class TipoChamadoCreateInput
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
    }
}
