using Foodler.Repository.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodler.Repository.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        IQueryable<TEntity> Query();
        void Insert(TEntity entity);
        void Save();
        void Update(TEntity entity);
        void Delete(TEntity entity);

    }
}
