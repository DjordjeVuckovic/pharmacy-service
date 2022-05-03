using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class MedicineController
    {
        private  readonly  MedicineService medicineService = new MedicineService();
        public List<Medicine> GetAllApproved()
        {
            return medicineService.GetAllApproved();

        }
        public Medicine GetById(string id)
        {
            return MedicineRepository.Instance.GetById(id);
        }
    }
}