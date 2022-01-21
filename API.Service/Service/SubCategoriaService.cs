using API.Domain.DTOs;
using API.Domain.DTOs.Categoria;
using API.Domain.DTOs.SubCategoria;
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
    public class SubCategoriaService : ISubCategoriaService
    {
        private IBaseRepository<SubCategoria> _baseRepository;
        private ISubCategoriaRepository _subCategoriaRepository;
        private readonly IMapper _mapper;

        public SubCategoriaService(IBaseRepository<SubCategoria> baseRepository, ISubCategoriaRepository subCategoriaRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _subCategoriaRepository = subCategoriaRepository;
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idSubCategoria)
        {
            return await _subCategoriaRepository.ExistAsync(idSubCategoria);
        }

        public async Task<ResponseBase<IEnumerable<SubCategoriaDto>>> GetListAsync()
        {
            ResponseBase<IEnumerable<SubCategoriaDto>> result = new ResponseBase<IEnumerable<SubCategoriaDto>>();

            try
            {
                var subCategorias = await _subCategoriaRepository.SelectListAsync();

                if (subCategorias.Sucess)
                {
                    result.Data = _mapper.Map<IEnumerable<SubCategoriaDto>>(subCategorias.Data);
                }
                else
                {
                    result.Sucess = false;
                    result.Data = null;
                    result.ErrorMessage = subCategorias.ErrorMessage;
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

        public async Task<ResponseBase<SubCategoriaDto>> Post(SubCategoriaCreateInput model)
        {
            ResponseBase<SubCategoriaDto> result = new ResponseBase<SubCategoriaDto>();

            try
            {
                var entity = _mapper.Map<SubCategoria>(model);

                var resultInsert = await _baseRepository.InsertAsync(entity);

                if (resultInsert.Sucess)
                {
                    result.Data = _mapper.Map<SubCategoriaDto>(resultInsert.Data);
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
