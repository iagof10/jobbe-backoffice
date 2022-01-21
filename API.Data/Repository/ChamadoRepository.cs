using API.Data.Context;
using API.Domain.DTOs;
using API.Domain.DTOs.Chamado;
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
    public class ChamadoRepository : IChamadoRepository
    {
        private readonly MyContext _context;
        private DbSet<Chamado> _datasetChamado;
        private readonly IMapper _mapper;

        public ChamadoRepository(MyContext context, IMapper mapper)
        {
            _context = context;
            _datasetChamado = _context.Set<Chamado>();
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idChamado)
        {
            return await _datasetChamado.AnyAsync(x => x.Id.Equals(idChamado));
        }

        public async Task<ResponseBase<IEnumerable<Chamado>>> SelectListAsync()
        {
            ResponseBase<IEnumerable<Chamado>> result = new ResponseBase<IEnumerable<Chamado>>();

            try
            {
                result.Data = await _datasetChamado.ToListAsync();
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
