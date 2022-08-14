using Foodler.Repository.Entities.Bases;

namespace Foodler.Repository.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        IQueryable<TEntity> Query();
        IQueryable<TEntity> FindByName(string name);
        void Insert(TEntity entity);
        void Save();
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
