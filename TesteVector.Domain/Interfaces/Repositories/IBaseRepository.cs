using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TesteVector.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        void Insert(TEntity obj);
        IList<TEntity> Search(Expression<Func<TEntity, bool>> filtro);
        TEntity? Select(Expression<Func<TEntity, bool>> filtro);
        IList<TEntity> Select();
        bool Any(Expression<Func<TEntity, bool>> filtro);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filtro);
        IEnumerable<TEntity> Include(params Expression<Func<TEntity, object>>[] includes);
    }
}
