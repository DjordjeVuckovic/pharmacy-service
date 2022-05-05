using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.Repository
{
    public class PatientAllergensRepository: GenericRepository<string, PatientAllergens>
    {
        private static readonly PatientAllergensRepository instance = new PatientAllergensRepository();

        static PatientAllergensRepository()
        {
        }

        private PatientAllergensRepository()
        {
        }

        public static PatientAllergensRepository Instance => instance;

        protected override string GetKey(PatientAllergens entity)
        {
            return entity.PatientJMBG + "-" + entity.AllergenName;
        }

        protected override string GetPath()
        {
            return @"../../Json/patientAllergens.json";
        }
        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }

        protected override void ShouldSerialize(PatientAllergens entity)
        {
            entity.ShouldSerialize = true;
        }
        public List<string> PatientAllergensList(string id)
        {
            List<string> temp = new List<string>();
            foreach (var pat in GetAllToList())
            {
                if (pat.PatientJMBG.Equals(id))
                {
                    temp.Add(pat.AllergenName);
                } 
            }

            return temp;
        }
    }
}
