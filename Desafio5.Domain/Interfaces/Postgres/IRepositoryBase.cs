using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Desafio5.Domain.Entity;
using Microsoft.EntityFrameworkCore.Query;

namespace Desafio5.Domain.Interfaces.Postgres
{
    public interface IRepositoryBase<K>
        where K : Base
    {
        Task<K> GetAsync(bool tracking, Func<IQueryable<K>, IIncludableQueryable<K, object>>? include = null, Expression<Func<K, bool>>? predicate = null);
        Task<List<K>> GetAllAsync();
        Task<List<K>> GetFilteredAsync(bool tracking, Func<IQueryable<K>, IIncludableQueryable<K, object>>? include = null, Expression<Func<K, bool>>? predicate = null, Func<IQueryable<K>, IOrderedQueryable<K>>? orderBy = null, int? page = null, int? perPage = null);
        Task<bool> FindAsync(Expression<Func<K, bool>> expression);
        Task<long> CountAsync(Expression<Func<K, bool>> expression);
        Guid Insert(K entity);
        void Update(K entity);
        void Remove(K entity);
        void Delete(K entity);
        
        public bool Commit();
    }
}