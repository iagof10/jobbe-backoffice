using API.Domain.DTOs;
using API.Domain.DTOs.Categoria;
using API.Domain.DTOs.SubCategoria;
using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Service
{
    public interface ISubCategoriaService
    {
        Task<bool> ExistAsync(long idSubCategoria);
        Task<ResponseBase<IEnumerable<SubCategoriaDto>>> GetListAsync();
        Task<ResponseBase<SubCategoriaDto>> GetAsync(long id);
        Task<ResponseBase<SubCategoriaDto>> Put(SubCategoriaUpdateInput model);
        Task<ResponseBase<SubCategoriaDto>> Post(SubCategoriaCreateInput model);
        Task<ResponseBase<bool>> Delete(long id);
    }
}
