using API.Domain.DTOs;
using API.Domain.DTOs.TelefoneUsuario;
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
    public class TelefoneUsuarioService : ITelefoneUsuarioService
    {
        private IBaseRepository<TelefoneUsuario> _baseRepository;
        private ITelefoneUsuarioRepository _telefoneUsuarioRepository;
        private readonly IMapper _mapper;

        public TelefoneUsuarioService(IBaseRepository<TelefoneUsuario> baseRepository, ITelefoneUsuarioRepository  telefoneUsuarioRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _telefoneUsuarioRepository = telefoneUsuarioRepository;
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idNumeroTelefone)
        {
            return await _telefoneUsuarioRepository.ExistAsync(idNumeroTelefone);
        }

        public async Task<ResponseBase<IEnumerable<TelefoneUsuarioDto>>> GetListAsync()
        {
            ResponseBase<IEnumerable<TelefoneUsuarioDto>> result = new ResponseBase<IEnumerable<TelefoneUsuarioDto>>();

            try
            {
                var telefoneUsuario = await _telefoneUsuarioRepository.SelectListAsync();

                if (telefoneUsuario.Sucess)
                {
                    result.Data = _mapper.Map<IEnumerable<TelefoneUsuarioDto>>(telefoneUsuario.Data);
                }
                else
                {
                    result.Sucess = false;
                    result.Data = null;
                    result.ErrorMessage = telefoneUsuario.ErrorMessage;
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
