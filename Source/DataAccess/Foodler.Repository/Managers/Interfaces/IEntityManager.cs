using Foodler.Repository.Entities.Bases;

namespace Foodler.Repository.Managers.Interfaces
{
    public interface IEntityManager<TEntity> where TEntity : EntityBase
    {
        TEntity Create(string name);
    }
}
