using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class MedicineService
    {
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

        public void Create(Medicine medicine)
        {
            MedicineRepository.Instance.Create(medicine);
        }
        public void Update(Medicine medicine)
        {
            MedicineRepository.Instance.Update(medicine);
        }

        public void Delete(Medicine medicine)
        {
            MedicineRepository.Instance.Delete(medicine.MedicineId);
        }
    }
}