using API.Domain.DTOs;
using API.Domain.DTOs.ChamadoStatus;
using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Repository
{
    public interface IChamadoStatusRepository
    {
        Task<bool> ExistAsync(long idChamadoStatus);
        Task<ResponseBase<IEnumerable<ChamadoStatus>>> SelectListAsync();
    }
}
