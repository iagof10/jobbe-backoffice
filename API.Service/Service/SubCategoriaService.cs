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
        private ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public SubCategoriaService(IBaseRepository<SubCategoria> baseRepository, ISubCategoriaRepository subCategoriaRepository, ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _subCategoriaRepository = subCategoriaRepository;
            _categoriaRepository = categoriaRepository;
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
                    var categorias = await _categoriaRepository.SelectListAsync();
                    var categoriasDto = _mapper.Map<IEnumerable<CategoriaDto>>(categorias.Data);

                    result.Data = _mapper.Map<IEnumerable<SubCategoriaDto>>(subCategorias.Data);

                    foreach (var item in result.Data)
                    {
                        item.Categoria = categoriasDto.Where(x => x.Id == item.CategoriaId).FirstOrDefault();
                    }
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

        public async Task<ResponseBase<SubCategoriaDto>> GetAsync(long id)
        {
            ResponseBase<SubCategoriaDto> result = new ResponseBase<SubCategoriaDto>();

            try
            {
                var subcategoria = await _baseRepository.SelectAsync(id);

                if (subcategoria.Sucess)
                {
                    result.Data = _mapper.Map<SubCategoriaDto>(subcategoria.Data);
                }
                else
                {
                    result.Sucess = false;
                    result.Data = null;
                    result.ErrorMessage = subcategoria.ErrorMessage;
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

        public async Task<ResponseBase<SubCategoriaDto>> Put(SubCategoriaUpdateInput model)
        {
            ResponseBase<SubCategoriaDto> result = new ResponseBase<SubCategoriaDto>();

            try
            {
                var entity = _mapper.Map<SubCategoria>(model);

                var resultUpdate = await _baseRepository.UpdateAsync(entity);

                if (resultUpdate.Sucess)
                {
                    result.Data = _mapper.Map<SubCategoriaDto>(resultUpdate.Data);
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
