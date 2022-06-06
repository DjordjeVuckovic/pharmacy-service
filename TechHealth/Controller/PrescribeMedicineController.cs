using System.Collections.Generic;
using System.Collections.ObjectModel;
using TechHealth.Model;
using TechHealth.Service;
using TechHealth.Service.IService;

namespace TechHealth.Controller
{
    public class PrescribeMedicineController
    {
        private readonly IPrescribeMedicineService prescribeMedicineService = new PrescribeMedicineService();
        public void Create(Prescription prescription)
        {
            prescribeMedicineService.Create(prescription);
        }

        public List<Prescription> GetAllByPatientId(string patientId)
        {
            return  prescribeMedicineService.GetAllByPatientId(patientId);
        }
        public List<Prescription> GetAll()
        {
            return prescribeMedicineService.GetAll();
        }

        public bool CheckAllergens(Medicine medicine, Patient patient)
        {
            return prescribeMedicineService.CheckAllergens(medicine, patient);
        }
    }
}