using System.Collections.Generic;
using System.Collections.ObjectModel;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class MedicineController
    {
        private  readonly  MedicineService medicineService = new MedicineService();

        public ObservableCollection<Medicine> GetAll()
        {
            return new ObservableCollection<Medicine>(medicineService.GetAll());
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
            medicineService.Delete(medicine);
        }
    }
}