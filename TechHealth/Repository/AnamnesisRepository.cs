using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Repository
{
    public class AnamnesisRepository:GenericRepository<string,Anamnesis>
    {
        private static readonly AnamnesisRepository instance = new AnamnesisRepository();
        
        static AnamnesisRepository()
        {
        }

        private AnamnesisRepository()
        {
        }
        public static AnamnesisRepository Instance => instance;
        protected override string GetPath()
        {
            return @"../../Json/anamnesis.json";
        }

        protected override string GetKey(Anamnesis entity)
        {
            return entity.AnamnesisId;
        }

        protected override void RemoveAllReference(string key)
        {
            throw new System.NotImplementedException();
        }
        public List<Anamnesis> GetByDoctorId(string id)
        {
            List<Anamnesis> anamneses = new List<Anamnesis>();
            foreach (var t in DictionaryValuesToList())
            {
                if (id.Equals(t.Appointment.Doctor.Jmbg))
                {
                    anamneses.Add(t);
                }
            }
            return anamneses;
        }
    }
}