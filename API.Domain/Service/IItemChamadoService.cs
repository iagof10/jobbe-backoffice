using API.Domain.DTOs;
using API.Domain.DTOs.Categoria;
using API.Domain.DTOs.ContatoPrestador;
using API.Domain.DTOs.ItemChamado;
using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Service
{
    public interface IItemChamadoService
    {
        Task<bool> ExistAsync(long idItemChamado);
        Task<ResponseBase<IEnumerable<ItemChamadoDto>>> GetListAsync();
    }
   
}
