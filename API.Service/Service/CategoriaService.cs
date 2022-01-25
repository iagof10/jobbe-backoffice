using API.Domain.DTOs;
using API.Domain.DTOs.Categoria;
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
    public class CategoriaService : ICategoriaService
    {
        private IBaseRepository<Categoria> _baseRepository;
        private ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(IBaseRepository<Categoria> baseRepository, ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<bool> ExistAsync(long idCategoria)
        {
            return await _categoriaRepository.ExistAsync(idCategoria);
        }

        public async Task<ResponseBase<CategoriaDto>> GetAsync(long id)
        {
            ResponseBase<CategoriaDto> result = new ResponseBase<CategoriaDto>();

            try
            {
                var categoria = await _baseRepository.SelectAsync(id);

                if (categoria.Sucess)
                {
                    result.Data = _mapper.Map<CategoriaDto>(categoria.Data);
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

        public async Task<ResponseBase<IEnumerable<CategoriaDto>>> GetListAsync()
        {
            ResponseBase<IEnumerable<CategoriaDto>> result = new ResponseBase<IEnumerable<CategoriaDto>>();

            try
            {
                var categorias = await _categoriaRepository.SelectListAsync();

                if (categorias.Sucess)
                {
                    result.Data = _mapper.Map<IEnumerable<CategoriaDto>>(categorias.Data);
                }
                else
                {
                    result.Sucess = false;
                    result.Data = null;
                    result.ErrorMessage = categorias.ErrorMessage;
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

        public async Task<ResponseBase<CategoriaDto>> Post(CategoriaCreateInput model)
        {
            ResponseBase<CategoriaDto> result = new ResponseBase<CategoriaDto>();

            try
            {
                var entity = _mapper.Map<Categoria>(model);

                var resultInsert = await _baseRepository.InsertAsync(entity);

                if (resultInsert.Sucess)
                {
                    result.Data = _mapper.Map<CategoriaDto>(resultInsert.Data);
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

        public async Task<ResponseBase<CategoriaDto>> Put(CategoriaUpdateInput model)
        {
            ResponseBase<CategoriaDto> result = new ResponseBase<CategoriaDto>();

            try
            {
                var entity = _mapper.Map<Categoria>(model);

                var resultUpdate = await _baseRepository.UpdateAsync(entity);

                if (resultUpdate.Sucess)
                {
                    result.Data = _mapper.Map<CategoriaDto>(resultUpdate.Data);
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
