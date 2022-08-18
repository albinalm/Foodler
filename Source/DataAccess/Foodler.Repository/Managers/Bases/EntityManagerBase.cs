using Foodler.Repository.Entities.Bases;
using Foodler.Repository.Managers.Interfaces;

namespace Foodler.Repository.Managers.Bases
{
    public class EntityManagerBase<TEntity> : IEntityManager<TEntity> where TEntity : EntityBase
    {
        public virtual TEntity Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"All entities must have a name", nameof(name));

            var entity = (TEntity?)Activator.CreateInstance(typeof(TEntity), name);

            if (entity == null)
                throw new ArgumentException("Method 'Create' returned null entity");

            return entity;
        }
    }
}
