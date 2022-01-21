using API.Domain.DTOs;
using API.Domain.DTOs.ComentarioPerfil;
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
    public class ComentarioPerfilService : IComentarioPerfilService
    {
        private IBaseRepository<ComentarioPerfil> _baseRepository;
        private IComentarioPerfilRepository _comentarioPerfilRepository;
        private readonly IMapper _mapper;

        public ComentarioPerfilService(IBaseRepository<ComentarioPerfil> baseRepository, IComentarioPerfilRepository comentarioPerfilRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _comentarioPerfilRepository = comentarioPerfilRepository;
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idComentarioPerfil)
        {
            return await _comentarioPerfilRepository.ExistAsync(idComentarioPerfil);
        }

        public async Task<ResponseBase<IEnumerable<ComentarioPerfilDto>>> GetListAsync()
        {
            ResponseBase<IEnumerable<ComentarioPerfilDto>> result = new ResponseBase<IEnumerable<ComentarioPerfilDto>>();

            try
            {
                var comentariosPerfil = await _comentarioPerfilRepository.SelectListAsync();

                if (comentariosPerfil.Sucess)
                {
                    result.Data = _mapper.Map<IEnumerable<ComentarioPerfilDto>>(comentariosPerfil.Data);
                }
                else
                {
                    result.Sucess = false;
                    result.Data = null;
                    result.ErrorMessage = comentariosPerfil.ErrorMessage;
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

        public async Task<ResponseBase<ComentarioPerfilDto>> Post(ComentarioPerfilCreateInput model)
        {
            ResponseBase<ComentarioPerfilDto> result = new ResponseBase<ComentarioPerfilDto>();

            try
            {
                var entity = _mapper.Map<ComentarioPerfil>(model);

                var resultInsert = await _baseRepository.InsertAsync(entity);

                if (resultInsert.Sucess)
                {
                    result.Data = _mapper.Map<ComentarioPerfilDto>(resultInsert.Data);
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
    }
}
