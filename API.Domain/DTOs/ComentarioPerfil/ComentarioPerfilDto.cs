using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Domain.DTOs.ComentarioPerfil
{
    public class ComentarioPerfilDto
    {
        public long Id { get; set; }
        public long IdUsuarioPrestador { get; set; }
        public long IdUsuarioAutorComentario { get; set; }
        public string NomeAutorComentario { get; set; }
        public string Comentario { get; set; }
    }
}
