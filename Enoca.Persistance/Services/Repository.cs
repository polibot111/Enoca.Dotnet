using Enoca.ApplicationLayer.Commons;
using Enoca.ApplicationLayer.Interface.Repositories;
using Enoca.ApplicationLayer.Wrappers;
using Enoca.Core.Entities;
using Enoca.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Persistance.Services
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        protected readonly MyDbContext _context;

        public Repository(MyDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();


        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> method = null, bool tracking = true)
        {
            var result = await Task.Run(() =>
            {
                var query = Table.AsQueryable();

                if (method != null)
                {
                    query = query.Where(method);
                }

                query = query.Where(x => !x.IsDeleted && !x.IsPassive);

                if (!tracking)
                    query = query.AsNoTracking();

                return query;
            });

            return result;
        }

        public async Task<IQueryable<T>> GetAllIncludeAsync(Expression<Func<T, bool>> method = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool tracking = true)
        {
            var result = await Task.Run(() =>
            {
                var query = Table.AsQueryable();

                if (include != null)
                {
                    query = include(query);
                }

                if (method != null)
                {
                    query = query.Where(method);
                }

                query = query.Where(x => !x.IsDeleted && !x.IsPassive);

                if (!tracking)
                    query = query.AsNoTracking();

                return query;
            });

            return result;
        }

        public async Task<WrapperQuereblePaginationResponse<T>> GetAllQuerablePagedReponseAsync<C>(C pagination, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            bool tracking = true, 
            Expression<Func<T, bool>> method = null) where C : PaginationDateRequest
        {
            WrapperQuereblePaginationResponse<T> response = new WrapperQuereblePaginationResponse<T>();

            var query = Table.AsQueryable().Where(x => !x.IsDeleted && !x.IsPassive);

            if (method != null)
            {
                query = query.Where(method);
            }

            if (!tracking)
                query = query.AsNoTracking();


            query = GenericApplyDateFilter.ApplyDateFilter(query, pagination.StartDate, pagination.EndDate);


            if (orderBy != null)
            {
                query = orderBy(query);
            }
            else
            {
                switch (pagination.OrderBy)
                {
                    case ApplicationLayer.Enums.OrderByEnum.AzalanSira:
                        query = query.OrderByDescending(x => x.CreatedDate);
                        break;
                    case ApplicationLayer.Enums.OrderByEnum.ArtanSira:
                        query = query.OrderBy(x => x.CreatedDate);
                        break;
                    case ApplicationLayer.Enums.OrderByEnum.Yok:
                        break;
                }
            }

            response.TotalCount = await query.CountAsync();

            if (pagination.Size == -1)
            {
                pagination.Size = response.TotalCount;
            }

            response.Data = query
                .Skip((pagination.Page - 1) * pagination.Size)
                .Take(pagination.Size);

            response.Size = pagination.Size;
            response.Page = pagination.Page;
            response.Succeeded = true;

            return response;
        }

        public async Task<T?> GetByIdAsync(int id, bool tracking = true)
        {
            var query = Table.AsQueryable().Where(x => x.IsDeleted == false && x.Id == id);
            if (!tracking)
                query = Table.AsNoTracking().Where(x => x.IsDeleted == false && x.Id == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T?> GetByIdIncludeAsync(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool tracking = true)
        {
            var query = Table.AsQueryable().Where(x => x.IsDeleted == false && x.Id == id);

            if (include != null)
                query = include(query);

            if (!tracking)
                query = Table.AsNoTracking().Where(x => x.IsDeleted == false && x.Id == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable().Where(x => x.IsDeleted == false);
            if (!tracking)
                query = Table.AsNoTracking().Where(x => x.IsDeleted == false);
            return await query.FirstOrDefaultAsync(method);
        }


        public async Task<T> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            entityEntry.State = EntityState.Added;
            return entityEntry.Entity;
        }

        public async Task<bool> UpdateAsync(T model)
        {
            var result = await Task.Run(() =>
            {
                var existingEntity = Table.Find(model.Id);

                if (existingEntity != null)
                {
                    _context.Entry(existingEntity).CurrentValues.SetValues(model);
                    return _context.Entry(existingEntity).State == EntityState.Modified;
                }

                return false;
            });

            return result;
        }


        public async Task<bool> UpdateIsDeletedAsync(T model)
        {
            var result = await Task.Run(() =>
            {
                model.IsDeleted = true;
                Table.Attach(model);
                var propertyEntry = _context.Entry(model).Property(x => x.IsDeleted);
                propertyEntry.IsModified = true;
                return propertyEntry.IsModified;
            });
            return result;
        }


        public async Task<int> SaveAsync()
           => await _context.SaveChangesAsync();


    }
}
