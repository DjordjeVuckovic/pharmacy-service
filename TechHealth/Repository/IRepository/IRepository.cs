using System.Collections.Generic;

namespace TechHealth.Repository.IRepository
{
    public interface IRepository<TEntity,TKey>
    {
        List<TEntity> GetAllToList();
        bool Create(TEntity entity);
        bool Update(TEntity entity);
        TEntity GetById(TKey key);
        bool Delete(TKey key);




    }
}