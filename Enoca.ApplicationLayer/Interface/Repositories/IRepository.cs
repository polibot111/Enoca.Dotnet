using Enoca.ApplicationLayer.Commons;
using Enoca.ApplicationLayer.Wrappers;
using Enoca.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Interface.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
    public interface IReadRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> method = null, bool tracking = true);

        Task<IQueryable<T>> GetAllIncludeAsync(Expression<Func<T, bool>> method = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool tracking = true);
        Task<T?> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T?> GetByIdAsync(int id, bool tracking = true);

        Task<T?> GetByIdIncludeAsync(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool tracking = true);

        Task<WrapperQuereblePaginationResponse<T>> GetAllQuerablePagedReponseAsync<C>(
        C pagination,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        bool tracking = true,
        Expression<Func<T, bool>> method = null)
        where C : PaginationDateRequest;
    }
    public interface IWriteRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T model);
        Task<bool> UpdateAsync(T model);
        Task<bool> UpdateIsDeletedAsync(T model);
        Task<int> SaveAsync();
    }
    public interface IRepository<T> : IWriteRepository<T>, IReadRepository<T> where T : BaseEntity
    {
    }
}
