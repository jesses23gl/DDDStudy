using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(Guid guid);

        TEntity Get(Guid guid);

        IQueryable<TEntity> GetAll();
    }
}
