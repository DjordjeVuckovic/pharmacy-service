using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace TechHealth.Repository
{
    public abstract class GenericRepository<TKey, TEntity>
    {
        protected abstract string GetPath();
        protected abstract TKey GetKey(TEntity entity);
        protected abstract void RemoveAllReference(TKey key);

        public Dictionary<TKey, TEntity> Deserialize()
        {
            string path = GetPath();
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                return new Dictionary<TKey, TEntity>();
            }

            string jsonRead = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Dictionary<TKey, TEntity>>(jsonRead);
        }

        public void Serialize(Dictionary<TKey, TEntity> entities)
        {
            string path = GetPath();
            string jsonWrite = JsonSerializer.Serialize(entities);
            File.WriteAllText(path,jsonWrite);
        }
        public bool Create(TEntity entity)
        {
            Dictionary<TKey, TEntity> entities = Deserialize();

            TKey key = GetKey(entity);

            if (entities.ContainsKey(key))
            {
                return false;
            }

            entities[key] = entity;

            Serialize(entities);

            return true;
        }

        public Dictionary<TKey, TEntity> GetAll()
        {
            return Deserialize();
        }

        public TEntity GetById(TKey key)
        {
            Dictionary<TKey, TEntity> entities = Deserialize();
            TEntity entity;

            if (!entities.TryGetValue(key, out entity))
            {
                return default;
            }

            return entity;
        }

        public bool Update(TEntity entity)
        {
            Dictionary<TKey, TEntity> entities = Deserialize();

            TKey key = GetKey(entity);

            if (!entities.ContainsKey(key))
            {
                return false;
            }

            entities[key] = entity;

            Serialize(entities);

            return true;
        }


        public bool Delete(TKey key)
        {
            Dictionary<TKey, TEntity> entities = Deserialize();

            bool remove = entities.Remove(key);

            //RemoveAllReference(key);

            Serialize(entities);

            return remove;
        }

        public List<TEntity> DictionaryToList()
        {
            return Deserialize().Values.ToList();
        }

        

    }
}