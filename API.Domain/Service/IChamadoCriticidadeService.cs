using API.Domain.DTOs;
using API.Domain.DTOs.ChamadoCriticidade;
using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Service
{
    public interface IChamadoCriticidadeService
    {
        Task<bool> ExistAsync(long idChamadoCriticidade);
        Task<ResponseBase<IEnumerable<ChamadoCriticidadeDto>>> GetListAsync();
        Task<ResponseBase<ChamadoCriticidadeDto>> Post(ChamadoCriticidadeCreateInput model);
    }
}
