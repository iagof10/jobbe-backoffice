using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string TipoUsuario { get; set; }
        public string Ativo { get; set; }
        public string Validado { get; set; }
        public long IdFotoPerfil { get; set; }
        public string NomeFotoPerfil { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ChaveUsuario { get; set; }
    }
}
