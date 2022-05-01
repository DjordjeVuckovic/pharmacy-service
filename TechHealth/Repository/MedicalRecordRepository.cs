using TechHealth.Model;

namespace TechHealth.Repository
{
    public class MedicalRecordRepository:GenericRepository<string,MedicalRecord>
    {
        private static readonly MedicalRecordRepository instance = new MedicalRecordRepository();
        
        static MedicalRecordRepository()
        {
        }

        private MedicalRecordRepository()
        {
        }
        public static MedicalRecordRepository Instance => instance;
        protected override string GetPath()
        {
            return @"../../Json/medicalrecord.json";
        }

        protected override string GetKey(MedicalRecord entity)
        {
            return entity.RecordId;
        }

        protected override void RemoveAllReference(string key)
        {
            throw new System.NotImplementedException();
        }

        protected override void ShouldSerialize(MedicalRecord entity)
        {
            entity.ShouldSerialize = true;
        }

        public MedicalRecord GetByPatientId(string id)
        {
            foreach (var med in GetAllToList())
            {
                if (med.Patient != null)
                {
                    if (med.Patient.Jmbg.Equals(id))
                    {
                        return med;
                    }
                }
            }

            return null;
        }
    }
}