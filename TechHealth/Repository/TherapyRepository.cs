using System;
using TechHealth.Model;

namespace TechHealth.Repository
{
    public class TherapyRepository : GenericRepository<string, Therapy>
    {
        private static readonly TherapyRepository instance = new TherapyRepository();

        static TherapyRepository()
        {
        }

        private TherapyRepository()
        {
        }

        public static TherapyRepository Instance => instance;



        protected override string GetPath()
        {
            return @"../../Json/therapy.json";
        }

        protected override string GetKey(Therapy entity)
        {
            return entity.TherapyId;
        }

        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }
    }
}