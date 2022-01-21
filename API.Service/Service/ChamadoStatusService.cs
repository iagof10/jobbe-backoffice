using API.Domain.DTOs;
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
    public class ChamadoStatusService : IChamadoStatusService
    {
        private IBaseRepository<ChamadoStatus> _baseRepository;
        private IChamadoStatusRepository _chamadoStatusRepository;
        private readonly IMapper _mapper;

        public ChamadoStatusService(IBaseRepository<ChamadoStatus> baseRepository, IChamadoStatusRepository chamadoStatusRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _chamadoStatusRepository = chamadoStatusRepository;
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idChamadoStatus)
        {
            return await _chamadoStatusRepository.ExistAsync(idChamadoStatus);
        }

        public async Task<ResponseBase<IEnumerable<ChamadoStatusDto>>> GetListAsync()
        {
            ResponseBase<IEnumerable<ChamadoStatusDto>> result = new ResponseBase<IEnumerable<ChamadoStatusDto>>();

            try
            {
                var chamadosStatus = await _chamadoStatusRepository.SelectListAsync();

                if (chamadosStatus.Sucess)
                {
                    result.Data = _mapper.Map<IEnumerable<ChamadoStatusDto>>(chamadosStatus.Data);
                }
                else
                {
                    result.Sucess = false;
                    result.Data = null;
                    result.ErrorMessage = chamadosStatus.ErrorMessage;
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

        public async Task<ResponseBase<ChamadoStatusDto>> Post(ChamadoStatusCreateInput model)
        {
            ResponseBase<ChamadoStatusDto> result = new ResponseBase<ChamadoStatusDto>();

            try
            {
                var entity = _mapper.Map<ChamadoStatus>(model);

                var resultInsert = await _baseRepository.InsertAsync(entity);

                if (resultInsert.Sucess)
                {
                    result.Data = _mapper.Map<ChamadoStatusDto>(resultInsert.Data);
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
