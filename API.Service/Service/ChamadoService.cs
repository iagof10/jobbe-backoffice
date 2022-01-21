using API.Domain.DTOs;
using API.Domain.DTOs.Chamado;
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
        private readonly IMapper _mapper;

        public ChamadoService(IBaseRepository<Chamado> baseRepository, IChamadoRepository chamadoRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _chamadoRepository = chamadoRepository;
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
    }
}
