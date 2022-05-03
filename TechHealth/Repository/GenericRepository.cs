using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TechHealth.Repository
{
    public abstract class GenericRepository<TKey, TEntity>
    {
        protected abstract string GetPath();
        protected abstract TKey GetKey(TEntity entity);
        protected abstract void RemoveAllReference(TKey key);
        protected abstract void ShouldSerialize(TEntity entity);
        public virtual TEntity Search(string search)
        {
            throw new NotImplementedException();
        }

        private Dictionary<TKey, TEntity> Deserialize()
        {

            string path = GetPath();
            if (!File.Exists(path))
            {
                File.Create(path);
                return new Dictionary<TKey, TEntity>();
            }

            string jsonRead = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Dictionary<TKey, TEntity>>(jsonRead);
        }

        private void Serialize(Dictionary<TKey, TEntity> entities)
        {
            string path = GetPath();

            string jsonWrite = JsonConvert.SerializeObject(entities, Formatting.Indented);
            File.WriteAllText(path, jsonWrite);
        }
        public bool Create(TEntity entity)
        {

            Dictionary<TKey, TEntity> entities = Deserialize();
            ShouldSerialize(entity);

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
            ShouldSerialize(entity);

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

            if (!entities.ContainsKey(key))
            {
                return false;
            }

            entities.Remove(key);

            //RemoveAllReference(key);

            Serialize(entities);

            return true;
        }

        public List<TEntity> GetAllToList()
        {
            return GetAll().Values.ToList();
        }
        public List<TKey> GetAllKeysToList()
        {
            List<TKey> entities = new List<TKey>();
            Dictionary<TKey, TEntity>.KeyCollection keyCollection = GetAll().Keys;
            foreach (var key in keyCollection)
            {
                entities.Add(key);
            }

            return entities;
        }


    }
}