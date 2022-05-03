using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class MedicalRecordService
    {
        public List<MedicalRecord> GetAll()
        {
            return MedicalRecordRepository.Instance.GetAllToList();
        }

        public bool Create(MedicalRecord medicalRecord)
        {
            return MedicalRecordRepository.Instance.Create(medicalRecord);
        }

        public bool Update(MedicalRecord medicalRecord)
        {
            return MedicalRecordRepository.Instance.Update(medicalRecord);
        }

        public bool Delete(string id)
        {
            return MedicalRecordRepository.Instance.Delete(id);
        }
    }
}
