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

        protected override void ShouldSerialize(Anamnesis entity)
        {
            entity.AnmnesisAppointment.ShouldSerialize = false;
        }

        public List<Anamnesis> GetByDoctorId(string id)
        {
            List<Anamnesis> anamneses = new List<Anamnesis>();
            foreach (var t in DictionaryValuesToList())
            {
                if (id.Equals(t.AnmnesisAppointment.Doctor.Jmbg))
                {
                    anamneses.Add(t);
                }
            }
            return anamneses;
        }

        public Anamnesis GetByAppointmentId(Appointment appointment)
        {
            Anamnesis retval=null;
            foreach (var t in DictionaryValuesToList())
            {
                if (appointment.IdAppointment == t.AnmnesisAppointment.IdAppointment)
                {
                    retval = t;
                }
            }

            return retval;
        }
        
    }
}