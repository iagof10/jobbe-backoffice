using API.Domain.Enum;
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
        public TipoUsuario TipoUsuario { get; set; }
        public long? CategoriaId { get; set; }
        public bool Ativo { get; set; }
        public bool Validado { get; set; }
        public string IdFotoPerfil { get; set; }
        public string NomeFotoPerfil { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ChaveUsuario { get; set; }
    }
}
