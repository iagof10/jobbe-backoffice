using API.Domain.DTOs;
using API.Domain.DTOs.ChamadoStatus;
using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Service
{
    public interface IChamadoStatusService
    {
        Task<bool> ExistAsync(long idChamadoStatus);
        Task<ResponseBase<IEnumerable<ChamadoStatusDto>>> GetListAsync();
        Task<ResponseBase<ChamadoStatusDto>> Post(ChamadoStatusCreateInput model);
    }
}
