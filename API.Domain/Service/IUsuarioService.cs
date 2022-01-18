using API.Domain.DTOs;
using API.Domain.DTOs.Usuario;
using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Service
{
    public interface IUsuarioService
    {
        Task<bool> ExistAsync(long idUsuario);
        Task<ResponseBase<IEnumerable<UsuarioDto>>> GetListAsync();
        Task<ResponseBase<UsuarioDto>> Post(UsuarioCreateInput model);
    }
}
