using API.Data.Context;
using API.Domain.DTOs;
using API.Domain.DTOs.ChamadoCriticidade;
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
    public class ChamadoCriticidadeRepository : IChamadoCriticidadeRepository
    {
        private readonly MyContext _context;
        private DbSet<ChamadoCriticidade> _datasetChamadoCriticidade;
        private readonly IMapper _mapper;

        public ChamadoCriticidadeRepository(MyContext context, IMapper mapper)
        {
            _context = context;
            _datasetChamadoCriticidade = _context.Set<ChamadoCriticidade>();
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idChamadoCriticidade)
        {
            return await _datasetChamadoCriticidade.AnyAsync(x => x.Id.Equals(idChamadoCriticidade));
        }

        public async Task<ResponseBase<IEnumerable<ChamadoCriticidade>>> SelectListAsync()
        {
            ResponseBase<IEnumerable<ChamadoCriticidade>> result = new ResponseBase<IEnumerable<ChamadoCriticidade>>();

            try
            {
                result.Data = await _datasetChamadoCriticidade.ToListAsync();
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
