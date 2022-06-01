using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class RejectedMedicineController
    {
        private readonly RejectedMedicineService rejectedMedicineService = new RejectedMedicineService();

        public List<RejectedMedicine> GetAllToList()
        {
            return rejectedMedicineService.GetAllToList();
        }
        public void Create(RejectedMedicine rejectedMedicine)
        {
            rejectedMedicineService.Create(rejectedMedicine);
        }

        public RejectedMedicine GetByMedicineId(string medId)
        {
            return rejectedMedicineService.GetByMedicineId(medId);
        }
    }
}