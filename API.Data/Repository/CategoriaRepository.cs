using API.Data.Context;
using API.Domain.DTOs;
using API.Domain.DTOs.Categoria;
using API.Domain.Entities;
using API.Domain.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly MyContext _context;
        private DbSet<Categoria> _datasetCategoria;
        private readonly IMapper _mapper;

        public CategoriaRepository(MyContext context, IMapper mapper)
        {
            _context = context;
            _datasetCategoria = _context.Set<Categoria>();
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idCategoria)
        {
            return await _datasetCategoria.AnyAsync(x => x.Id.Equals(idCategoria));
        }

        public async Task<ResponseBase<IEnumerable<Categoria>>> SelectListAsync()
        {
            ResponseBase<IEnumerable<Categoria>> result = new ResponseBase<IEnumerable<Categoria>>();

            try
            {
                result.Data = await _datasetCategoria.ToListAsync();
            }
            catch (Exception ex)
            {
                result.Sucess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
