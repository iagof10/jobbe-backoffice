using API.Domain.DTOs;
using API.Domain.DTOs.Categoria;
using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Repository
{
    public interface IItemChamadoRepository
    {
        Task<bool> ExistAsync(long idItemChamado);
        Task<ResponseBase<IEnumerable<ItemChamado>>> SelectListAsync();
    }
}
