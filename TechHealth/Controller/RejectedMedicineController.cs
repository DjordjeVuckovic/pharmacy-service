using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Service;
using TechHealth.Service.IService;

namespace TechHealth.Controller
{
    public class RejectedMedicineController
    {
        private readonly IRejectedMedicineService rejectedMedicineService = new RejectedMedicineService();

        public List<RejectedMedicine> GetAllToList()
        {
            return rejectedMedicineService.GetAll();
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