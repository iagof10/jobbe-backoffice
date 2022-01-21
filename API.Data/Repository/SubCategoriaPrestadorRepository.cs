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
    public class SubCategoriaPrestadorRepository : ISubCategoriaPrestadorRepository
    {
        private readonly MyContext _context;
        private DbSet<SubCategoriaPrestador> _datasetSubCategoriaPrestador;
        private readonly IMapper _mapper;

        public SubCategoriaPrestadorRepository(MyContext context, IMapper mapper)
        {
            _context = context;
            _datasetSubCategoriaPrestador = _context.Set<SubCategoriaPrestador>();
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idSubCategoriaPrestador)
        {
            return await _datasetSubCategoriaPrestador.AnyAsync(x => x.Id.Equals(idSubCategoriaPrestador));
        }

        public async Task<ResponseBase<IEnumerable<SubCategoriaPrestador>>> SelectListAsync()
        {
            ResponseBase<IEnumerable<SubCategoriaPrestador>> result = new ResponseBase<IEnumerable<SubCategoriaPrestador>>();

            try
            {
                result.Data = await _datasetSubCategoriaPrestador.ToListAsync();
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
