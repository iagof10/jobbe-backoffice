using API.Domain.DTOs;
using API.Domain.DTOs.TipoChamado;
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
    public class TipoChamadoService : ITipoChamadoService
    {
        private IBaseRepository<TipoChamado> _baseRepository;
        private ITipoChamadoRepository _tipoChamadoRepository;
        private readonly IMapper _mapper;

        public TipoChamadoService(IBaseRepository<TipoChamado> baseRepository, ITipoChamadoRepository tipoChamadoRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _tipoChamadoRepository = tipoChamadoRepository;
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idSubCategoria)
        {
            return await _tipoChamadoRepository.ExistAsync(idSubCategoria);
        }

        public async Task<ResponseBase<IEnumerable<TipoChamadoDto>>> GetListAsync()
        {
            ResponseBase<IEnumerable<TipoChamadoDto>> result = new ResponseBase<IEnumerable<TipoChamadoDto>>();

            try
            {
                var tipoChamado = await _tipoChamadoRepository.SelectListAsync();

                if (tipoChamado.Sucess)
                {
                    result.Data = _mapper.Map<IEnumerable<TipoChamadoDto>>(tipoChamado.Data);
                }
                else
                {
                    result.Sucess = false;
                    result.Data = null;
                    result.ErrorMessage = tipoChamado.ErrorMessage;
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

        public async Task<ResponseBase<TipoChamadoDto>> GetAsync(long id)
        {
            ResponseBase<TipoChamadoDto> result = new ResponseBase<TipoChamadoDto>();

            try
            {
                var tipoChamado = await _baseRepository.SelectAsync(id);

                if (tipoChamado.Sucess)
                {
                    result.Data = _mapper.Map<TipoChamadoDto>(tipoChamado.Data);
                }
                else
                {
                    result.Sucess = false;
                    result.Data = null;
                    result.ErrorMessage = tipoChamado.ErrorMessage;
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

        public async Task<ResponseBase<TipoChamadoDto>> Post(TipoChamadoCreateInput model)
        {
            ResponseBase<TipoChamadoDto> result = new ResponseBase<TipoChamadoDto>();

            try
            {
                var entity = _mapper.Map<TipoChamado>(model);

                var resultInsert = await _baseRepository.InsertAsync(entity);

                if (resultInsert.Sucess)
                {
                    result.Data = _mapper.Map<TipoChamadoDto>(resultInsert.Data);
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

        public async Task<ResponseBase<TipoChamadoDto>> Put(TipoChamadoUpdateInput model)
        {
            ResponseBase<TipoChamadoDto> result = new ResponseBase<TipoChamadoDto>();

            try
            {
                var entity = _mapper.Map<TipoChamado>(model);

                var resultUpdate = await _baseRepository.UpdateAsync(entity);

                if (resultUpdate.Sucess)
                {
                    result.Data = _mapper.Map<TipoChamadoDto>(resultUpdate.Data);
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

        public async Task<ResponseBase<bool>> Delete(long id)
        {
            ResponseBase<bool> result = new ResponseBase<bool>();

            try
            {
                var resultDelete = await _baseRepository.DeleteAsync(id);

                if (resultDelete)
                {
                    result.Data = resultDelete;
                }
                else
                {
                    result.Sucess = false;
                    result.Data = false;
                    result.ErrorMessage = "Erro ao deletar.";
                }

            }
            catch (Exception ex)
            {
                result.Sucess = false;
                result.Data = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

    }
}
