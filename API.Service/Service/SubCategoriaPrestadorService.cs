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
    public class SubCategoriaPrestadorService : ISubCategoriaPrestadorService
    {
        private ISubCategoriaPrestadorRepository _subCategoriaPrestadorRepository;
        private readonly IMapper _mapper;

        public SubCategoriaPrestadorService(ISubCategoriaPrestadorRepository subCategoriaPrestadorRepository, IMapper mapper)
        {
            _subCategoriaPrestadorRepository = subCategoriaPrestadorRepository;
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idSubCategoriaPrestador)
        {
            return await _subCategoriaPrestadorRepository.ExistAsync(idSubCategoriaPrestador);
        }

        public async Task<ResponseBase<IEnumerable<SubCategoriaPrestadorDto>>> GetListAsync()
        {
            ResponseBase<IEnumerable<SubCategoriaPrestadorDto>> result = new ResponseBase<IEnumerable<SubCategoriaPrestadorDto>>();

            try
            {
                var subCategoriasPrestador = await _subCategoriaPrestadorRepository.SelectListAsync();

                if (subCategoriasPrestador.Sucess)
                {
                    result.Data = _mapper.Map<IEnumerable<SubCategoriaPrestadorDto>>(subCategoriasPrestador.Data);
                }
                else
                {
                    result.Sucess = false;
                    result.Data = null;
                    result.ErrorMessage = subCategoriasPrestador.ErrorMessage;
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
