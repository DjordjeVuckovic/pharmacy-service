using System.Collections.Generic;

namespace TechHealth.Controller.IController
{
    public interface IController<TEntity,TKey>
    {
        List<TEntity> GetAll();
        void Create(TEntity entity);
        void Update(TEntity entity);
        TEntity GetById(TKey key);
        void Delete(TKey key);
        
    }
}