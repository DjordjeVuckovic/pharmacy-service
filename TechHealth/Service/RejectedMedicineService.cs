using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class RejectedMedicineService
    {
        public List<RejectedMedicine> GetAllToList()
        {
            return RejectedMedicineRepository.Instance.GetAllToList();
        }
        public void Create(RejectedMedicine rejectedMedicine)
        {
            RejectedMedicineRepository.Instance.Create(rejectedMedicine);
        }

        public RejectedMedicine GetByMedicineId(string medId)
        {
            RejectedMedicine rejectedMedicine = new RejectedMedicine();
            foreach (var rm in GetAllToList())
            {
                if (medId == rm.Medicine.MedicineId)
                {
                    rejectedMedicine = rm;
                    break;
                }
            }
            return rejectedMedicine;
        }
    }
}