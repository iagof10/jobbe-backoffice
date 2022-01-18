using API.Domain.DTOs;
using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<ResponseBase<T>> SelectAsync(long id);
        Task<ResponseBase<IEnumerable<T>>> SelectAsync();
        Task<ResponseBase<T>> InsertAsync(T item);
        Task<ResponseBase<IEnumerable<T>>> InsertAllAsync(IEnumerable<T> itens);
        Task<ResponseBase<T>> UpdateAsync(T item);
        Task<bool> DeleteAsync(long id);
        Task<bool> ExistAsync(long id);

    }
}
