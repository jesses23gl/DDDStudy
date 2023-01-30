using Domain.Interfaces;
using Infrastruct.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastruct.Data
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly StudyContext _db;
        public BaseRepository(StudyContext context)
        {
            _db = context;
        }
        public virtual void Add(TEntity obj)
        {
            _db.Set<TEntity>().Add(obj);
            SaveChanges();
        }

        public virtual TEntity Get(Guid id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _db.Set<TEntity>();
        }

        public virtual void Update(TEntity obj)
        {
            _db.Set<TEntity>().Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            _db.Set<TEntity>().Remove(_db.Set<TEntity>().Find(id));
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}