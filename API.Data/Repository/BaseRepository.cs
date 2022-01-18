using API.Data.Context;
using API.Domain.DTOs;
using API.Domain.Entities;
using API.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly MyContext _context;
        private DbSet<T> _dataset;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var entity = await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(id));
                if (entity == null)
                {
                    return false;
                }

                _dataset.Remove(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ExistAsync(long id)
        {
            return await _dataset.AnyAsync(x => x.Id.Equals(id));
        }

        public async Task<ResponseBase<IEnumerable<T>>> InsertAllAsync(IEnumerable<T> itens)
        {
            ResponseBase<IEnumerable<T>> result = new ResponseBase<IEnumerable<T>>();

            try
            {
                foreach (var item in itens)
                {
                    item.CreateAt = DateTime.UtcNow;
                }
                await _dataset.AddRangeAsync(itens);
                await _context.SaveChangesAsync();

                result.Data = itens;
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Sucess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public async Task<ResponseBase<T>> InsertAsync(T item)
        {
            ResponseBase<T> result = new ResponseBase<T>();

            try
            {
                item.CreateAt = DateTime.UtcNow;
                _dataset.Add(item);
                await _context.SaveChangesAsync();

                result.Data = item;
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Sucess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public async Task<ResponseBase<T>> SelectAsync(long id)
        {
            ResponseBase<T> result = new ResponseBase<T>();

            try
            {
                result.Data = await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(id));
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Sucess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public async Task<ResponseBase<IEnumerable<T>>> SelectAsync()
        {
            ResponseBase<IEnumerable<T>> result = new ResponseBase<IEnumerable<T>>();

            try
            {
                result.Data = await _dataset.ToListAsync();
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Sucess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public async Task<ResponseBase<T>> UpdateAsync(T item)
        {
            ResponseBase<T> result = new ResponseBase<T>();

            try
            {
                var entity = await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(item.Id));
                if (entity == null)
                {
                    return null;
                }

                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = entity.CreateAt;
                _context.Entry(entity).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();

                result.Data = item;
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Sucess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}

