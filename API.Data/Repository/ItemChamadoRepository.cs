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
    public class ItemChamadoRepository : IItemChamadoRepository
    {
        private readonly MyContext _context;
        private DbSet<ItemChamado> _datasetItemChamado;
        private readonly IMapper _mapper;

        public ItemChamadoRepository(MyContext context, IMapper mapper)
        {
            _context = context;
            _datasetItemChamado = _context.Set<ItemChamado>();
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idItemChamado)
        {
            return await _datasetItemChamado.AnyAsync(x => x.Id.Equals(idItemChamado));
        }

        public async Task<ResponseBase<IEnumerable<ItemChamado>>> SelectListAsync()
        {
            ResponseBase<IEnumerable<ItemChamado>> result = new ResponseBase<IEnumerable<ItemChamado>>();

            try
            {
                result.Data = await _datasetItemChamado.ToListAsync();
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
