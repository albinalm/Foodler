using Foodler.Repository.Context;
using Foodler.Repository.Entities.Bases;
using Foodler.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Foodler.Repository.Repositories.Bases
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepository<TEntity> where TEntity : EntityBase
    {
        private FoodlerDatabaseContext context;
        public RepositoryBase(FoodlerDatabaseContext context)
        {
            this.context = context;
        }

        public abstract IQueryable<TEntity> Query();

        public void Insert(TEntity entity)
        {
            if (entity == null)
                throw new InvalidOperationException("Entity cannot be null");

            context.Add(entity);
        }
        public void InsertRange(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any())
                throw new InvalidOperationException("Entities cannot be null or empty");

            context.AddRange(entities);
        }
        public TEntity? FindById(int id)
        {
            return (TEntity?)context.Find(typeof(TEntity), id);
        }
        public virtual IQueryable<TEntity>? FindByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException("Name cannot be null or whitespace");

            return Query().Where(entity => entity.Name == name);
        }
        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new InvalidOperationException("Entity cannot be null");

            context.Remove(entity);
        }
        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new InvalidOperationException("Entity cannot be null");

            context.Entry(entity).State = EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
