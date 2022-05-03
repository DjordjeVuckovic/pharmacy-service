using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class MedicalRecordController
    {
        private readonly MedicalRecordService MedicalRecordService = new MedicalRecordService();
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

            return MedicalRecordService.Create(medicalRecord);
        }

        public bool Update(string id, Bloodtype bloodType, Patient patient, string weight, string height, string chronicDiseases, string parentDiseases, string martialStatus, EmlpoymentData emlpoymentData)
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

            return MedicalRecordService.Update(medicalRecord);
        }

        public bool Delete(string id)
        {
            return MedicalRecordService.Delete(id);
        }
    }
}
