﻿using System.Collections.Generic;

namespace TechHealth.Repository
{
    public interface IGenericRepository<T, ID>
    {
        List<T> GetAll();
        void Update(T entity);
        void Delete(ID key);
        void Delete(T entity);
        void Save(T entity);
        void CreateOrUpdate(T entity);
        T FindById(ID key);
    }
}
