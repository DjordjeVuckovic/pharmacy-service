using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class PrescribeMedicineService
    {
        public bool Create(Prescription prescription)
        {
            return PrescribeMedicineRepository.Instance.Create(prescription);
        }

        public List<Prescription> GetAll()
        {
            return PrescribeMedicineRepository.Instance.GetAllToList();
        }
    }
}