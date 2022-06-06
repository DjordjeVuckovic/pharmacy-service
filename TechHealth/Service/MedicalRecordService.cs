using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service.IService;

namespace TechHealth.Service
{
    public class MedicalRecordService:IMedicalRecordService
    {
        public List<MedicalRecord> GetAll()
        {
            return MedicalRecordRepository.Instance.GetAllToList();
        }

        public MedicalRecord GetByPatientId(string patientId)
        {
            return MedicalRecordRepository.Instance.GetByPatientId(patientId);
        }

        public bool Create(MedicalRecord medicalRecord)
        {
            return MedicalRecordRepository.Instance.Create(medicalRecord);
        }

        public bool Update(MedicalRecord medicalRecord)
        {
            return MedicalRecordRepository.Instance.Update(medicalRecord);
        }

        public MedicalRecord GetById(string key)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            return MedicalRecordRepository.Instance.Delete(id);
        }
    }
}
