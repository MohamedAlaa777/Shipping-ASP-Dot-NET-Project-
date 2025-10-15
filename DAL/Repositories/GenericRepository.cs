using DAL.Contracts;
using DAL.Data;
using DAL.Exceptions;
using DAL.Models;
using Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{   
    //(where T : BaseTable) to access the common atributes that we need for add , delete , update & other methods
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseTable
    {
        private readonly ShippingContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly ILogger<GenericRepository<T>> _logger;
        // constructor injection
        public GenericRepository(ShippingContext context, ILogger<GenericRepository<T>> logger)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _logger = logger;
        }

        public async Task<(bool, Guid)> Add(T entity)
        {
            try
            {
                entity.CreatedDate = DateTime.Now;
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return (true, entity.Id);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger);
            }
        }


        // Logical delete
        public async Task<bool> ChangeStatus(Guid id,Guid userId, int status = 1)
        {
            try
            {
                var entity = await GetById(id);
                if (entity == null) return false;

                entity.CurrentState = status;
                entity.UpdatedBy = userId;
                entity.UpdatedDate = DateTime.Now;

                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            // it is not a silent catch
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger);
            }
        }
        // direct delete from database
        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var entity = await GetById(id);
                if (entity == null) return false;

                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger);
            }
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                return await _dbSet.Where(a => a.CurrentState > 0).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger);
            }
        }

        public async Task<T?> GetById(Guid id)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(a => a.Id == id);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger);
            }
        }

        public async Task<T?> GetByIdAsNoTracking(Guid id)
        {
            try
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger);
            }
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                var dbData = await GetById(entity.Id);
                if (dbData == null) return false;

                entity.CreatedDate = dbData.CreatedDate;
                entity.CreatedBy = dbData.CreatedBy;
                entity.CurrentState = dbData.CurrentState;
                entity.UpdatedDate = DateTime.Now;

                //_context.Entry(entity).State = EntityState.Modified;
                _context.Entry(dbData).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger);
            }
        }

        public async Task<bool> Update(Guid id, Action<T> updateAction)
        {
            try
            {
                var entity = await GetById(id);
                if (entity == null)
                    return false;

                //Apply the updates from outside
                updateAction(entity);

                //Track only changed fields
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger);
            }
        }

        public async Task<T?> GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            try
            {
                return await _dbSet.Where(filter).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger);
            }
        }

        // Method to get a list of records based on a filter
        public async Task<List<T>> GetList(Expression<Func<T, bool>> filter)
        {
            try
            {
                return await _dbSet.Where(filter).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger);
            }
        }

        public async Task<List<TResult>> GetList<TResult>(
            Expression<Func<T, bool>>? filter = null,
            Expression<Func<T, TResult>>? selector = null,
            Expression<Func<T, object>>? orderBy = null,
            bool isDescending = false,
            params Expression<Func<T, object>>[] includers)
        {
            try
            {
                IQueryable<T> query = _dbSet.AsQueryable();

                // Apply includes
                foreach (var include in includers)
                    query = query.Include(include);

                // Apply filter
                if (filter != null)
                    query = query.Where(filter);

                // Apply ordering
                if (orderBy != null)
                    query = isDescending
                        ? query.OrderByDescending(orderBy)
                        : query.OrderBy(orderBy);

                query = query.AsNoTracking();

                // Apply projection
                if (selector != null)
                    return await query.Select(selector).ToListAsync();

                return await query.Cast<TResult>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger); // Or your custom exception
            }
        }

        public async Task<PagedResult<TResult>> GetPagedList<TResult>(
        int pageNumber,
        int pageSize,
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, TResult>>? selector = null,
        Expression<Func<T, object>>? orderBy = null,
        bool isDescending = false,
        params Expression<Func<T, object>>[] includers)
        {
            try
            {
                IQueryable<T> query = _dbSet.AsQueryable();

                // Apply includes
                foreach (var include in includers)
                    query = query.Include(include);

                // Apply filter
                if (filter != null)
                    query = query.Where(filter);

                // Total count before pagination
                int totalCount = await query.CountAsync();

                // Apply ordering
                if (orderBy != null)
                {
                    query = isDescending
                        ? query.OrderByDescending(orderBy)
                        : query.OrderBy(orderBy);
                }

                query = query.AsNoTracking();

                // Apply paging
                query = query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize);

                // Apply projection
                List<TResult> items;
                if (selector != null)
                    items = await query.Select(selector).ToListAsync();
                else
                    items = await query.Cast<TResult>().ToListAsync();

                // Calculate total pages
                int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                return new PagedResult<TResult>
                {
                    Items = items,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = totalCount,
                    TotalPages = totalPages
                };
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger);
            }
        }
    }
}
