using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IBaseRepositoty<TEntity>
    {
        void Create(TEntity entity);
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> Get();
        void Update(TEntity item);
        TEntity? GetById(int id);
    }

    public abstract class  BaseRepositoty<TEntity> : IBaseRepositoty<TEntity> 
        where TEntity : class
    {
        protected DbContext _context;
        protected DbSet<TEntity> _dbSet;

        public BaseRepositoty(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public virtual IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public virtual TEntity? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public  virtual void Create(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public virtual void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
