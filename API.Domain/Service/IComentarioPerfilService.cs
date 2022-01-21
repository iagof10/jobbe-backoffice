using API.Domain.DTOs;
using API.Domain.DTOs.ComentarioPerfil;
using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Service
{
    public interface IComentarioPerfilService
    {
        Task<bool> ExistAsync(long idComentarioPerfil);
        Task<ResponseBase<IEnumerable<ComentarioPerfilDto>>> GetListAsync();
        Task<ResponseBase<ComentarioPerfilDto>> Post(ComentarioPerfilCreateInput model);
    }
}
