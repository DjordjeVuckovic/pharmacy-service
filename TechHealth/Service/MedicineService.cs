using System.Collections.Generic;
using TechHealth.Exceptions;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service.IService;

namespace TechHealth.Service
{
    public class MedicineService:IMedicineService
    {
        public List<Medicine> GetAll()
        {
            return MedicineRepository.Instance.GetAllToList();
        }
        
        public List<Medicine> GetAllApproved()
        {
            var temp = new List<Medicine>();
            foreach (var medicine in MedicineRepository.Instance.GetAllToList())
            {
                if (medicine.MedicineStatus == MedicineStatus.Approved)
                {
                    temp.Add(medicine);
                }
            }

            return temp;
        }
        public Medicine GetById(string id)
        {
            return MedicineRepository.Instance.GetById(id);
        }
        

        public bool Create(Medicine medicine)
        {
            return  MedicineRepository.Instance.Create(medicine);
        }
        public bool Update(Medicine medicine)
        {
            return MedicineRepository.Instance.Update(medicine);
        }

        public bool Delete(string medicineId)
        {
            return  MedicineRepository.Instance.Delete(medicineId);
        }
    }
}