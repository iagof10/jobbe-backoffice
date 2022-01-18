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
    public class SubCategoriaRepository : ISubCategoriaRepository
    {
        private readonly MyContext _context;
        private DbSet<SubCategoria> _datasetSubCategoria;
        private readonly IMapper _mapper;

        public SubCategoriaRepository(MyContext context, IMapper mapper)
        {
            _context = context;
            _datasetSubCategoria = _context.Set<SubCategoria>();
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idSubCategoria)
        {
            return await _datasetSubCategoria.AnyAsync(x => x.Id.Equals(idSubCategoria));
        }

        public async Task<ResponseBase<IEnumerable<SubCategoria>>> SelectListAsync()
        {
            ResponseBase<IEnumerable<SubCategoria>> result = new ResponseBase<IEnumerable<SubCategoria>>();

            try
            {
                result.Data = await _datasetSubCategoria.ToListAsync();
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
