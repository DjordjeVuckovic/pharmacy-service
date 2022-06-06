using System.Collections.Generic;

namespace TechHealth.Service.IService
{
    public interface IService<TEntity,TKey>
    {
        List<TEntity> GetAll();
        bool Create(TEntity entity);
        bool Update(TEntity entity);
        TEntity GetById(TKey key);
        bool Delete(TKey key);
    }
}