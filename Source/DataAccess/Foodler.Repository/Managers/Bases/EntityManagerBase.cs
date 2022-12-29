using Foodler.Repository.Entities.Bases;
using Foodler.Repository.Managers.Interfaces;
using Foodler.Repository.Repositories.Interfaces;

namespace Foodler.Repository.Managers.Bases
{
    public class EntityManagerBase<TEntity> : IEntityManager<TEntity> where TEntity : EntityBase
    {
        private readonly IRepository<TEntity> entityRepository;

        public EntityManagerBase(IRepository<TEntity> entityRepository)
        {
            this.entityRepository = entityRepository;
        }
        
        public virtual TEntity Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"All entities must have a name", nameof(name));

            var entity = (TEntity?)Activator.CreateInstance(typeof(TEntity), name);

            if (entity == null)
                throw new ArgumentException("Method 'Create' returned null entity");

            return entity;
        }

        public virtual void HardDelete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException($"You need to specify an entity to delete");

            entityRepository.Delete(entity);
            entityRepository.Save();
        }

        public virtual void SoftDelete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException($"You need to specify an entity to delete");

            entity.IsDeleted = true;

            entityRepository.Update(entity);
            entityRepository.Save();
        }
    }
}
