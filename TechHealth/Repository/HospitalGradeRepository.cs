using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.Repository
{
    public class HospitalGradeRepository : GenericRepository<string, HospitalGrade>
    {
        static HospitalGradeRepository()
        {
        }
        private HospitalGradeRepository()
        {
        }
        public static HospitalGradeRepository Instance { get; } = new HospitalGradeRepository();

        protected override string GetKey(HospitalGrade entity)
        {
            return entity.Patient.Jmbg; //svaka ocena bolnice je vezana za zasebnog pacijenta
        }

        protected override string GetPath()
        {
            return @"../../Json/hospitalrating.json";
        }

        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }

        protected override void ShouldSerialize(HospitalGrade entity)
        {
            entity.Patient.ShouldSerialize = false;
        }
    }
}
