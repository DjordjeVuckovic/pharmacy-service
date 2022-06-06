using System.Collections.Generic;
using System.Windows.Documents;

namespace TechHealth.Repository
{
    public interface IRepository<TEntity,TId>
    {
        List<TEntity> GetAll();
        bool Create(TEntity entity);
        bool Update(TEntity entity);
        TEntity GetById(TId id);
        bool Delete(TId id);




    }
}