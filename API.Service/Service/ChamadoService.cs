using API.Domain.DTOs;
using API.Domain.DTOs.Chamado;
using API.Domain.DTOs.ChamadoStatus;
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
using API.Domain.DTOs.TipoChamado;
using API.Domain.DTOs.Usuario;

namespace API.Service.Service
{
    public class ChamadoService : IChamadoService
    {
        private IBaseRepository<Chamado> _baseRepository;
        private IChamadoRepository _chamadoRepository;
        private IChamadoStatusRepository _chamadoStatusRepository;
        private IChamadoCriticidadeRepository _chamadoCriticidadeRepository;
        private ITipoChamadoRepository _tipoChamadoRepository;
        private IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public ChamadoService(IBaseRepository<Chamado> baseRepository, IChamadoRepository chamadoRepository, IChamadoStatusRepository chamadoStatusRepository, IChamadoCriticidadeRepository chamadoCriticidadeRepository, ITipoChamadoRepository tipoChamadoRepository, IUsuarioRepository usuarioRepository,IMapper mapper)
        {
            _baseRepository = baseRepository;
            _chamadoRepository = chamadoRepository;
            _chamadoStatusRepository = chamadoStatusRepository;
            _chamadoCriticidadeRepository = chamadoCriticidadeRepository;
            _tipoChamadoRepository = tipoChamadoRepository;
            _usuarioRepository = usuarioRepository;

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

                    var chamadoStatus = await _chamadoStatusRepository.SelectListAsync();
                    var chamadoStatusDto = _mapper.Map<IEnumerable<ChamadoStatusDto>>(chamadoStatus.Data);
                    
                    var chamadoCriticidade = await _chamadoCriticidadeRepository.SelectListAsync();
                    var chamadoCriticidadeDto = _mapper.Map<IEnumerable<ChamadoCriticidadeDto>>(chamadoCriticidade.Data);

                    var tipoChamado = await _tipoChamadoRepository.SelectListAsync();
                    var tipoChamadoDto = _mapper.Map<IEnumerable<TipoChamadoDto>>(tipoChamado.Data);

                    var usuario = await _usuarioRepository.SelectListAsync();
                    var usuarioDto = _mapper.Map<IEnumerable<UsuarioDto>>(usuario.Data);

                    foreach (var item in result.Data)
                    {
                        item.ChamadoStatus = chamadoStatusDto.Where(x => x.Id == item.IdChamadoStatus).FirstOrDefault();
                    }
                    foreach (var item in result.Data)
                    {
                        item.ChamadoCriticidade = chamadoCriticidadeDto.Where(x => x.Id == item.IdChamadoCriticidade).FirstOrDefault();
                    }
                    foreach (var item in result.Data)
                    {
                        item.TipoChamado = tipoChamadoDto.Where(x => x.Id == item.IdTipoChamado).FirstOrDefault();
                    }
                    foreach (var item in result.Data)
                    {
                        item.UsuarioChamado = usuarioDto.Where(x => x.Id == item.IdUsuario).FirstOrDefault();
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
                var chamado = await _baseRepository.SelectAsync(id);

                if (chamado.Sucess)
                { 
                    result.Data = _mapper.Map<ChamadoDto>(chamado.Data);

                    var chamadoStatus = await _chamadoStatusRepository.SelectListAsync();
                    var chamadoStatusDto = _mapper.Map<IEnumerable<ChamadoStatusDto>>(chamadoStatus.Data);

                    var chamadoCriticidade = await _chamadoCriticidadeRepository.SelectListAsync();
                    var chamadoCriticidadeDto = _mapper.Map<IEnumerable<ChamadoCriticidadeDto>>(chamadoCriticidade.Data);

                    var tipoChamado = await _tipoChamadoRepository.SelectListAsync();
                    var tipoChamadoDto = _mapper.Map<IEnumerable<TipoChamadoDto>>(tipoChamado.Data);

                    var usuario = await _usuarioRepository.SelectListAsync();
                    var usuarioDto = _mapper.Map<IEnumerable<UsuarioDto>>(usuario.Data);

                    result.Data.ChamadoStatus = chamadoStatusDto.Where(x => x.Id == result.Data.IdChamadoStatus).FirstOrDefault();

                    result.Data.ChamadoCriticidade = chamadoCriticidadeDto.Where(x => x.Id == result.Data.IdChamadoCriticidade).FirstOrDefault();

                    result.Data.TipoChamado = tipoChamadoDto.Where(x => x.Id == result.Data.IdTipoChamado).FirstOrDefault();

                    result.Data.UsuarioChamado = usuarioDto.Where(x => x.Id == result.Data.IdUsuario).FirstOrDefault();

                }
                else
                {
                    result.Sucess = false;
                    result.Data = null;
                    result.ErrorMessage = chamado.ErrorMessage;
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
