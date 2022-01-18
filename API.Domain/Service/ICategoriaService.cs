using API.Domain.DTOs;
using API.Domain.DTOs.Categoria;
using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Service
{
    public interface ICategoriaService
    {
        Task<bool> ExistAsync(long idCategoria);
        Task<ResponseBase<IEnumerable<CategoriaDto>>> GetListAsync();
        Task<ResponseBase<CategoriaDto>> Post(CategoriaCreateInput model);
    }
}
