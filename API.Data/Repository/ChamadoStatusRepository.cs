using API.Data.Context;
using API.Domain.DTOs;
using API.Domain.DTOs.ChamadoStatus;
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
    public class ChamadoStatusRepository : IChamadoStatusRepository
    {
        private readonly MyContext _context;
        private DbSet<ChamadoStatus> _datasetChamadoStatus;
        private readonly IMapper _mapper;

        public ChamadoStatusRepository(MyContext context, IMapper mapper)
        {
            _context = context;
            _datasetChamadoStatus = _context.Set<ChamadoStatus>();
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idChamadoStatus)
        {
            return await _datasetChamadoStatus.AnyAsync(x => x.Id.Equals(idChamadoStatus));
        }

        public async Task<ResponseBase<IEnumerable<ChamadoStatus>>> SelectListAsync()
        {
            ResponseBase<IEnumerable<ChamadoStatus>> result = new ResponseBase<IEnumerable<ChamadoStatus>>();

            try
            {
                result.Data = await _datasetChamadoStatus.ToListAsync();
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
