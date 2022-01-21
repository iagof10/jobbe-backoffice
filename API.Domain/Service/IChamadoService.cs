using API.Domain.DTOs;
using API.Domain.DTOs.Chamado;
using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Service
{
    public interface IChamadoService
    {
        Task<bool> ExistAsync(long idChamado);
        Task<ResponseBase<IEnumerable<ChamadoDto>>> GetListAsync();
        Task<ResponseBase<ChamadoDto>> Post(ChamadoCreateInput model);
    }
}
