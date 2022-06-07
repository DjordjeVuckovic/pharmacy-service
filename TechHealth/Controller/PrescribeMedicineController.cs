using System.Collections.Generic;
using System.Collections.ObjectModel;
using TechHealth.Controller.IController;
using TechHealth.Model;
using TechHealth.Service;
using TechHealth.Service.IService;

namespace TechHealth.Controller
{
    public class PrescribeMedicineController:IPrescribeMedicineController
    {
        private readonly IPrescribeMedicineService prescribeMedicineService = new PrescribeMedicineService();
        public void Create(Prescription prescription)
        {
            prescribeMedicineService.Create(prescription);
        }

        public void Update(Prescription entity)
        {
            throw new System.NotImplementedException();
        }

        public Prescription GetById(string key)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new System.NotImplementedException();
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