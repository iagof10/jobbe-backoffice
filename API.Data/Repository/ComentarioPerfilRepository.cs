using API.Data.Context;
using API.Domain.DTOs;
using API.Domain.DTOs.ComentarioPerfil;
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
    public class ComentarioPerfilRepository : IComentarioPerfilRepository
    {
        private readonly MyContext _context;
        private DbSet<ComentarioPerfil> _datasetComentarioPerfil;
        private readonly IMapper _mapper;

        public ComentarioPerfilRepository(MyContext context, IMapper mapper)
        {
            _context = context;
            _datasetComentarioPerfil = _context.Set<ComentarioPerfil>();
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idComentarioPerfil)
        {
            return await _datasetComentarioPerfil.AnyAsync(x => x.Id.Equals(idComentarioPerfil));
        }

        public async Task<ResponseBase<IEnumerable<ComentarioPerfil>>> SelectListAsync()
        {
            ResponseBase<IEnumerable<ComentarioPerfil>> result = new ResponseBase<IEnumerable<ComentarioPerfil>>();

            try
            {
                result.Data = await _datasetComentarioPerfil.ToListAsync();
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
