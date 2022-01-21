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
    public class ContatoPrestadorRepository : IContatoPrestadorRepository
    {
        private readonly MyContext _context;
        private DbSet<ContatoPrestador> _datasetContatoPrestador;
        private readonly IMapper _mapper;

        public ContatoPrestadorRepository(MyContext context, IMapper mapper)
        {
            _context = context;
            _datasetContatoPrestador = _context.Set<ContatoPrestador>();
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idContatoPrestador)
        {
            return await _datasetContatoPrestador.AnyAsync(x => x.Id.Equals(idContatoPrestador));
        }

        public async Task<ResponseBase<IEnumerable<ContatoPrestador>>> SelectListAsync()
        {
            ResponseBase<IEnumerable<ContatoPrestador>> result = new ResponseBase<IEnumerable<ContatoPrestador>>();

            try
            {
                result.Data = await _datasetContatoPrestador.ToListAsync();
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
