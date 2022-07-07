using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TesteVector.Domain.Interfaces.Repositories;
using TesteVector.Infra.Data.Context;

namespace TesteVector.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly TesteVectorContext _testeVectorContext;

        public BaseRepository(TesteVectorContext testeVectorContext) => _testeVectorContext = testeVectorContext;

        public bool Any(Expression<Func<TEntity, bool>> filtro) => _testeVectorContext.Set<TEntity>().Any(filtro);

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filtro) => _testeVectorContext.Set<TEntity>().FirstOrDefault(filtro);

        public IEnumerable<TEntity> Include(params Expression<Func<TEntity, object>>[] includes)
        {
            DbSet<TEntity>? dbSet = _testeVectorContext.Set<TEntity>();

            IEnumerable<TEntity> query = null;
            foreach (var include in includes)
            {
                query = dbSet.Include(include);
            }

            return query ?? dbSet;
        }

        public void Insert(TEntity obj)
        {
            _testeVectorContext.Add(obj);
            _testeVectorContext.SaveChanges();
        }

        public IList<TEntity> Search(Expression<Func<TEntity, bool>> filtro)
        {
            List<TEntity>? objeto = _testeVectorContext.Set<TEntity>()?.Where(filtro)?.AsNoTracking()?.ToList();
            return objeto ?? new List<TEntity>();
        }

        public TEntity? Select(Expression<Func<TEntity, bool>> filtro)
        {
            TEntity? objeto = _testeVectorContext.Set<TEntity>()?.Where(filtro)?.AsNoTracking()?.FirstOrDefault();
            return objeto;
        }

        public IList<TEntity> Select() => _testeVectorContext.Set<TEntity>().AsNoTracking().ToList();
    }
}
