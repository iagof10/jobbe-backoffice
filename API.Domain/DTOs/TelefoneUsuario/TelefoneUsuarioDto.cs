using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Domain.DTOs.TelefoneUsuario
{
    public class TelefoneUsuarioDto
    {
        public long UsuarioId { get; set; }
        public long Id { get; set; }
        public string NumeroTelefone { get; set; }

    }
}
