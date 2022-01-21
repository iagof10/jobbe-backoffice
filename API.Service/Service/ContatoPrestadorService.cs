using API.Domain.DTOs;
using API.Domain.DTOs.Categoria;
using API.Domain.DTOs.ContatoPrestador;
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
    public class ContatoPrestadorService : IContatoPrestadorService
    {
        private IContatoPrestadorRepository _contatoPrestadorRepository;
        private readonly IMapper _mapper;

        public ContatoPrestadorService(IContatoPrestadorRepository contatoPrestadorRepository, IMapper mapper)
        {
            _contatoPrestadorRepository = contatoPrestadorRepository;
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idContatoPrestador)
        {
            return await _contatoPrestadorRepository.ExistAsync(idContatoPrestador);
        }

        public async Task<ResponseBase<IEnumerable<ContatoPrestadorDto>>> GetListAsync()
        {
            ResponseBase<IEnumerable<ContatoPrestadorDto>> result = new ResponseBase<IEnumerable<ContatoPrestadorDto>>();

            try
            {
                var contatosPrestador = await _contatoPrestadorRepository.SelectListAsync();

                if (contatosPrestador.Sucess)
                {
                    result.Data = _mapper.Map<IEnumerable<ContatoPrestadorDto>>(contatosPrestador.Data);
                }
                else
                {
                    result.Sucess = false;
                    result.Data = null;
                    result.ErrorMessage = contatosPrestador.ErrorMessage;
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
