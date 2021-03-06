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
        Task<ResponseBase<TipoChamadoDto>> GetAsync(long id);
        Task<ResponseBase<TipoChamadoDto>> Post(TipoChamadoCreateInput model);
        Task<ResponseBase<TipoChamadoDto>> Put(TipoChamadoUpdateInput model);
        Task<ResponseBase<bool>> Delete(long id);
    }
}
