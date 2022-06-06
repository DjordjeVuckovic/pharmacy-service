using System.Collections.Generic;
using System.Collections.ObjectModel;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service;
using TechHealth.Service.IService;

namespace TechHealth.Controller
{
    public class MedicineController
    {
        private  readonly  IMedicineService medicineService = new MedicineService();

        public List<Medicine> GetAll()
        {
            return medicineService.GetAll();
        }
        public List<Medicine> GetAllApproved()
        {
            return medicineService.GetAllApproved();

        }
        public Medicine GetById(string id)
        {
            return MedicineRepository.Instance.GetById(id);
        }

        public void Create(Medicine medicine)
        {
            medicineService.Create(medicine);
        }

        public void Update(Medicine medicine)
        {
            medicineService.Update(medicine);
        }

        public void Delete(Medicine medicine)
        {
            medicineService.Delete(medicine.MedicineId);
        }
    }
}