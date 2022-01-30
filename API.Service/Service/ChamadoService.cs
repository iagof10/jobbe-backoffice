using API.Domain.DTOs;
using API.Domain.DTOs.Chamado;
using API.Domain.DTOs.ChamadoStatus;
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
    public class ChamadoService : IChamadoService
    {
        private IBaseRepository<Chamado> _baseRepository;
        private IChamadoRepository _chamadoRepository;
        private IChamadoStatusRepository _chamadoStatusRepository;
        private readonly IMapper _mapper;

        public ChamadoService(IBaseRepository<Chamado> baseRepository, IChamadoRepository chamadoRepository, IChamadoStatusRepository chamadoStatusRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _chamadoRepository = chamadoRepository;
            _chamadoStatusRepository = chamadoStatusRepository;
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idChamado)
        {
            return await _chamadoRepository.ExistAsync(idChamado);
        }

        public async Task<ResponseBase<IEnumerable<ChamadoDto>>> GetListAsync()
        {
            ResponseBase<IEnumerable<ChamadoDto>> result = new ResponseBase<IEnumerable<ChamadoDto>>();

            try
            {
                var chamados = await _chamadoRepository.SelectListAsync();

                if (chamados.Sucess)
                {
                    result.Data = _mapper.Map<IEnumerable<ChamadoDto>>(chamados.Data);
                }
                if (chamados.Sucess)
                {
                    var chamadoStatus = await _chamadoStatusRepository.SelectListAsync();
                    var chamadoStatusDto = _mapper.Map<IEnumerable<ChamadoStatusDto>>(chamadoStatus.Data);

                    result.Data = _mapper.Map<IEnumerable<ChamadoDto>>(chamados.Data);

                    foreach (var item in result.Data)
                    {
                        item.ChamadoStatus = chamadoStatusDto.Where(x => x.Id == item.IdChamadoStatus).FirstOrDefault();
                    }
                }
                else
                {
                    result.Sucess = false;
                    result.Data = null;
                    result.ErrorMessage = chamados.ErrorMessage;
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

        public async Task<ResponseBase<ChamadoDto>> GetAsync(long id)
        {
            ResponseBase<ChamadoDto> result = new ResponseBase<ChamadoDto>();

            try
            {
                var categoria = await _baseRepository.SelectAsync(id);

                if (categoria.Sucess)
                {
                    result.Data = _mapper.Map<ChamadoDto>(categoria.Data);
                }
                else
                {
                    result.Sucess = false;
                    result.Data = null;
                    result.ErrorMessage = categoria.ErrorMessage;
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

        public async Task<ResponseBase<ChamadoDto>> Post(ChamadoCreateInput model)
        {
            ResponseBase<ChamadoDto> result = new ResponseBase<ChamadoDto>();

            try
            {
                var entity = _mapper.Map<Chamado>(model);

                var resultInsert = await _baseRepository.InsertAsync(entity);

                if (resultInsert.Sucess)
                {
                    result.Data = _mapper.Map<ChamadoDto>(resultInsert.Data);
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

        public async Task<ResponseBase<ChamadoDto>> Put(ChamadoUpdateInput model)
        {
            ResponseBase<ChamadoDto> result = new ResponseBase<ChamadoDto>();

            try
            {
                var entity = _mapper.Map<Chamado>(model);

                var resultUpdate = await _baseRepository.UpdateAsync(entity);

                if (resultUpdate.Sucess)
                {
                    result.Data = _mapper.Map<ChamadoDto>(resultUpdate.Data);
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
