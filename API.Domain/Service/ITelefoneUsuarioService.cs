using API.Domain.DTOs;
using API.Domain.DTOs.TelefoneUsuario;
using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Service
{
    public interface ITelefoneUsuarioService
    {
        Task<bool> ExistAsync(long idNumeroTelefone);
        Task<ResponseBase<IEnumerable<TelefoneUsuarioDto>>> GetListAsync();
    }
}
