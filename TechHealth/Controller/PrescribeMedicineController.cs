using System.Collections.Generic;
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

        public List<Prescription> GetAll()
        {
            return prescribeMedicineService.GetAll();
        }
    }
}