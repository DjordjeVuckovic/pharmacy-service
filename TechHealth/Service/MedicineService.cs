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
                if (medicine.Approved)
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
    }
}