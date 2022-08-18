using Foodler.Repository.Entities.Bases;

namespace Foodler.Repository.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        IQueryable<TEntity> Query();
        IQueryable<TEntity>? FindByName(string name);
        TEntity? FindById(int id);
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        void Save();
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
