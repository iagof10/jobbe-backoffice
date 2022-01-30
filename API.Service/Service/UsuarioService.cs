using API.Domain.DTOs;
using API.Domain.DTOs.Usuario;
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
    public class UsuarioService : IUsuarioService
    {
        private IBaseRepository<Usuario> _baseRepository;
        private IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IBaseRepository<Usuario> baseRepository, IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idUsuario)
        {
            return await _usuarioRepository.ExistAsync(idUsuario);
        }

        public async Task<ResponseBase<UsuarioDto>> GetAsync(long id)
        {
            ResponseBase<UsuarioDto> result = new ResponseBase<UsuarioDto>();

            try
            {
                var usuario = await _baseRepository.SelectAsync(id);

                if (usuario.Sucess)
                {
                    result.Data = _mapper.Map<UsuarioDto>(usuario.Data);
                }
                else
                {
                    result.Sucess = false;
                    result.Data = null;
                    result.ErrorMessage = usuario.ErrorMessage;
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

        public async Task<ResponseBase<IEnumerable<UsuarioDto>>> GetListAsync()
        {
            ResponseBase<IEnumerable<UsuarioDto>> result = new ResponseBase<IEnumerable<UsuarioDto>>();

            try
            {
                var usuarios = await _usuarioRepository.SelectListAsync();

                if (usuarios.Sucess)
                {
                    result.Data = _mapper.Map<IEnumerable<UsuarioDto>>(usuarios.Data);
                }
                else
                {
                    result.Sucess = false;
                    result.Data = null;
                    result.ErrorMessage = usuarios.ErrorMessage;
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


        public async Task<ResponseBase<UsuarioDto>> Post(UsuarioCreateInput model)
        {
            ResponseBase<UsuarioDto> result = new ResponseBase<UsuarioDto>();

            try
            {
                var entity = _mapper.Map<Usuario>(model);

                var resultInsert = await _baseRepository.InsertAsync(entity);

                if (resultInsert.Sucess)
                {
                    result.Data = _mapper.Map<UsuarioDto>(resultInsert.Data);
                }
                else
                {
                    result.Sucess = false;
                    result.Data = null;
                    result.ErrorMessage = resultInsert.ErrorMessage;
                }

            }
            catch (Exception ex)
            {
                result.Sucess = false;
                result.Data = null;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public async Task<ResponseBase<UsuarioDto>> Put(UsuarioUpdateInput model)
        {
            ResponseBase<UsuarioDto> result = new ResponseBase<UsuarioDto>();

            try
            {
                var entity = _mapper.Map<Usuario>(model);

                var resultUpdate = await _baseRepository.UpdateAsync(entity);

                if (resultUpdate.Sucess)
                {
                    result.Data = _mapper.Map<UsuarioDto>(resultUpdate.Data);
                }
                else
                {
                    result.Sucess = false;
                    result.Data = null;
                    result.ErrorMessage = resultUpdate.ErrorMessage;
                }

            }
            catch (Exception ex)
            {
                result.Sucess = false;
                result.Data = null;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
