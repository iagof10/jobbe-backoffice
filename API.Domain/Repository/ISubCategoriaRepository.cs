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
    public interface ISubCategoriaRepository
    {
        Task<bool> ExistAsync(long idSubCategoria);
        Task<ResponseBase<IEnumerable<SubCategoria>>> SelectListAsync();
    }
}
