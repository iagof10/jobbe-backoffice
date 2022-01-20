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
    public class TipoChamadoRepository : ITipoChamadoRepository
    {
        private readonly MyContext _context;
        private DbSet<TipoChamado> _datasetTipoChamado;
        private readonly IMapper _mapper;

        public TipoChamadoRepository(MyContext context, IMapper mapper)
        {
            _context = context;
            _datasetTipoChamado = _context.Set<TipoChamado>();
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idTipoChamado)
        {
            return await _datasetTipoChamado.AnyAsync(x => x.Id.Equals(idTipoChamado));
        }

        public async Task<ResponseBase<IEnumerable<TipoChamado>>> SelectListAsync()
        {
            ResponseBase<IEnumerable<TipoChamado>> result = new ResponseBase<IEnumerable<TipoChamado>>();

            try
            {
                result.Data = await _datasetTipoChamado.ToListAsync();
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
