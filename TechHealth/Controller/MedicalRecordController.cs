using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service;
using TechHealth.Service.IService;

namespace TechHealth.Controller
{
    public class MedicalRecordController
    {
        private readonly IMedicalRecordService medicalRecordService = new MedicalRecordService();
        public List<MedicalRecord> GetAll()
        {
            return MedicalRecordRepository.Instance.GetAllToList();
        }
        public bool Create(string id, Bloodtype bloodType, Patient patient, string weight, string height, string chronicDiseases, string parentDiseases, string martialStatus, EmlpoymentData emlpoymentData)
        {
            var medicalRecord = new MedicalRecord();

            medicalRecord.RecordId = id;
            medicalRecord.BloodType = bloodType;
            medicalRecord.Patient = patient;
            medicalRecord.Weight = weight;
            medicalRecord.Height = height;
            medicalRecord.ChronicDiseases = chronicDiseases;
            medicalRecord.ParentDiseases = parentDiseases;
            medicalRecord.MartialStatus = martialStatus;
            medicalRecord.EmlpoymentData = emlpoymentData;

            return medicalRecordService.Create(medicalRecord);
        }

        public bool Update(string id, Bloodtype bloodType, Patient patient, string weight, string height, string chronicDiseases, string parentDiseases, string martialStatus, EmlpoymentData emlpoymentData)
        {
            var medicalRecord = new MedicalRecord
            {
                RecordId = id,
                BloodType = bloodType,
                Patient = patient,
                Weight = weight,
                Height = height,
                ChronicDiseases = chronicDiseases,
                ParentDiseases = parentDiseases,
                MartialStatus = martialStatus,
                EmlpoymentData = emlpoymentData
            };

            return medicalRecordService.Update(medicalRecord);
        }

        public bool Delete(string id)
        {
            return medicalRecordService.Delete(id);
        }
        public MedicalRecord GetByPatientId(string patientId)
        {
            return medicalRecordService.GetByPatientId(patientId);
        }
    }
}
