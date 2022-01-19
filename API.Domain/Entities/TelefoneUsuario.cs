using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Entities
{
    public class TelefoneUsuario : BaseEntity
    {
        public long UsuarioId { get; set; }
        public string NumeroTelefone { get; set; }
    }
}
