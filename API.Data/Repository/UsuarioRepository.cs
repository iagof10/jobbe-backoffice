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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MyContext _context;
        private DbSet<Usuario> _datasetUsuario;
        private readonly IMapper _mapper;

        public UsuarioRepository(MyContext context, IMapper mapper)
        {
            _context = context;
            _datasetUsuario = _context.Set<Usuario>();
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idUsuario)
        {
            return await _datasetUsuario.AnyAsync(x => x.Id.Equals(idUsuario));
        }

        public async Task<ResponseBase<IEnumerable<Usuario>>> SelectListAsync()
        {
            ResponseBase<IEnumerable<Usuario>> result = new ResponseBase<IEnumerable<Usuario>>();

            try
            {
                result.Data = await _datasetUsuario.ToListAsync();
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
