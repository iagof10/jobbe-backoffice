using API.Domain.DTOs;
using API.Domain.DTOs.TipoChamado;
using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Service
{
    public interface ITipoChamadoService
    {
        Task<bool> ExistAsync(long idTipoChamado);
        Task<ResponseBase<IEnumerable<TipoChamadoDto>>> GetListAsync();
        Task<ResponseBase<TipoChamadoDto>> Post(TipoChamadoCreateInput model);
    }
}
