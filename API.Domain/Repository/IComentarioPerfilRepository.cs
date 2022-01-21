using API.Domain.DTOs;
using API.Domain.DTOs.Categoria;
using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Repository
{
    public interface IComentarioPerfilRepository
    {
        Task<bool> ExistAsync(long idComentarioPerfil);
        Task<ResponseBase<IEnumerable<ComentarioPerfil>>> SelectListAsync();
    }
}
