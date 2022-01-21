using API.Domain.DTOs;
using API.Domain.DTOs.ChamadoCriticidade;
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
    public class ChamadoCriticidadeService : IChamadoCriticidadeService
    {
        private IBaseRepository<ChamadoCriticidade> _baseRepository;
        private IChamadoCriticidadeRepository _chamadoCriticidadeRepository;
        private readonly IMapper _mapper;

        public ChamadoCriticidadeService(IBaseRepository<ChamadoCriticidade> baseRepository, IChamadoCriticidadeRepository chamadoCriticidadeRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _chamadoCriticidadeRepository = chamadoCriticidadeRepository;
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idChamadoCriticidade)
        {
            return await _chamadoCriticidadeRepository.ExistAsync(idChamadoCriticidade);
        }

        public async Task<ResponseBase<IEnumerable<ChamadoCriticidadeDto>>> GetListAsync()
        {
            ResponseBase<IEnumerable<ChamadoCriticidadeDto>> result = new ResponseBase<IEnumerable<ChamadoCriticidadeDto>>();

            try
            {
                var chamados = await _chamadoCriticidadeRepository.SelectListAsync();

                if (chamados.Sucess)
                {
                    result.Data = _mapper.Map<IEnumerable<ChamadoCriticidadeDto>>(chamados.Data);
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

        public async Task<ResponseBase<ChamadoCriticidadeDto>> Post(ChamadoCriticidadeCreateInput model)
        {
            ResponseBase<ChamadoCriticidadeDto> result = new ResponseBase<ChamadoCriticidadeDto>();

            try
            {
                var entity = _mapper.Map<ChamadoCriticidade>(model);

                var resultInsert = await _baseRepository.InsertAsync(entity);

                if (resultInsert.Sucess)
                {
                    result.Data = _mapper.Map<ChamadoCriticidadeDto>(resultInsert.Data);
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
