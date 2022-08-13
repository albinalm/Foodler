using FoodlerRepository.Database.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodlerRepository.Database.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        private FoodlerDatabaseContext context;
        public RepositoryBase(FoodlerDatabaseContext context)
        {
            this.context = context;
        }

        public void Insert(TEntity entity)
        {
            if (entity == null)
                throw new InvalidOperationException("Entity cannot be null");

            context.Add(entity);
        }
        public TEntity FindById(int id)
        {
            return (TEntity?)context.Find(typeof(TEntity), id)
                   ?? throw new NullReferenceException("");
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
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
