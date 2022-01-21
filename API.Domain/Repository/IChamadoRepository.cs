using API.Domain.DTOs;
using API.Domain.DTOs.Chamado;
using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Repository
{
    public interface IChamadoRepository
    {
        Task<bool> ExistAsync(long idChamado);
        Task<ResponseBase<IEnumerable<Chamado>>> SelectListAsync();
    }
}
