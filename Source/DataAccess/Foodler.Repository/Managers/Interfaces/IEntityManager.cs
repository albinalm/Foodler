using Foodler.Repository.Entities.Bases;
using Foodler.Repository.Entities.Recipes.Interfaces;

namespace Foodler.Repository.Managers.Interfaces
{
    public interface IEntityManager<TEntity> where TEntity : class
    {
        abstract TEntity Create(string name);
    }
}
