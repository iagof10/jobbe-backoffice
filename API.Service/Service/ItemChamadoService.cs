using API.Domain.DTOs;
using API.Domain.DTOs.Categoria;
using API.Domain.DTOs.ContatoPrestador;
using API.Domain.DTOs.ItemChamado;
using API.Domain.Entities;
using API.Domain.Repository;
using API.Domain.Service;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Service.Service
{
    public class ItemChamadoService : IItemChamadoService
    {
        private IItemChamadoRepository _itemChamadoRepository;
        private readonly IMapper _mapper;

        public ItemChamadoService(IItemChamadoRepository itemChamadoRepository, IMapper mapper)
        {
            _itemChamadoRepository = itemChamadoRepository;
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idItemChamado)
        {
            return await _itemChamadoRepository.ExistAsync(idItemChamado);
        }

        public async Task<ResponseBase<IEnumerable<ItemChamadoDto>>> GetListAsync()
        {
            ResponseBase<IEnumerable<ItemChamadoDto>> result = new ResponseBase<IEnumerable<ItemChamadoDto>>();

            try
            {
                var itensPrestador = await _itemChamadoRepository.SelectListAsync();

                if (itensPrestador.Sucess)
                {
                    result.Data = _mapper.Map<IEnumerable<ItemChamadoDto>>(itensPrestador.Data);
                }
                else
                {
                    result.Sucess = false;
                    result.Data = null;
                    result.ErrorMessage = itensPrestador.ErrorMessage;
                }

            }
            catch (Exception e)
            {
                result.Sucess = false;
                result.Data = null;
                result.ErrorMessage = e.Message;
            }

            return result;
        }
    }
}
