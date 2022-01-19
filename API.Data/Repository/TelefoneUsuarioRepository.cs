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
    public class TelefoneUsuarioRepository : ITelefoneUsuarioRepository
    {
        private readonly MyContext _context;
        private DbSet<TelefoneUsuario> _datasetTelefoneUsuario;
        private readonly IMapper _mapper;

        public TelefoneUsuarioRepository(MyContext context, IMapper mapper)
        {
            _context = context;
            _datasetTelefoneUsuario = _context.Set<TelefoneUsuario>();
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idUsuario)
        {
            return await _datasetTelefoneUsuario.AnyAsync(x => x.Id.Equals(idUsuario));
        }

        public async Task<ResponseBase<IEnumerable<TelefoneUsuario>>> SelectListAsync()
        {
            ResponseBase<IEnumerable<TelefoneUsuario>> result = new ResponseBase<IEnumerable<TelefoneUsuario>>();

            try
            {
                result.Data = await _datasetTelefoneUsuario.ToListAsync();
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
