﻿using System;
using TechHealth.Model;

namespace TechHealth.Repository
{
    public class ManagerRepository:GenericRepository<string,Manager>
    {
        private static readonly ManagerRepository instance = new ManagerRepository();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static ManagerRepository()
        {
        }

        private ManagerRepository()
        {
        }
        public static ManagerRepository Instance => instance;
        protected override string GetPath()
        {
            return @"../../Json/manager.json";
        }

        protected override string GetKey(Manager entity)
        {
            return entity.Jmbg;
        }

        protected override void RemoveAllReference(string key)
        {
            throw new System.NotImplementedException();
        }

        protected override void ShouldSerialize(Manager entity)
        {
            //skip
        }

        public Manager GetManagerByUser(string user)
        {
            foreach (var mng in GetAllToList())
            {
                if (mng.Username.Equals(user))
                {
                    return mng;
                }
            }

            return null;
        }
    }
}