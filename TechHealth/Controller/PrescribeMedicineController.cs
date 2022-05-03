using System.Collections.Generic;
using System.Collections.ObjectModel;
using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class PrescribeMedicineController
    {
        private readonly PrescribeMedicineService prescribeMedicineService = new PrescribeMedicineService();
        public void Create(Prescription prescription)
        {
            prescribeMedicineService.Create(prescription);
        }

        public ObservableCollection<Prescription> GetAllByPatientId(string patientId)
        {
            return new ObservableCollection<Prescription>(prescribeMedicineService.GetAllByPatientId(patientId));
        }
        public List<Prescription> GetAll()
        {
            return prescribeMedicineService.GetAll();
        }
    }
}