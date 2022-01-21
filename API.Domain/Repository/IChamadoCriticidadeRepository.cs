using API.Domain.DTOs;
using API.Domain.DTOs.ChamadoCriticidade;
using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Repository
{
    public interface IChamadoCriticidadeRepository
    {
        Task<bool> ExistAsync(long idChamadoCriticidade);
        Task<ResponseBase<IEnumerable<ChamadoCriticidade>>> SelectListAsync();
    }
}
