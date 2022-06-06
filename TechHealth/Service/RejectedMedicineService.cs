using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service.IService;

namespace TechHealth.Service
{
    public class RejectedMedicineService:IRejectedMedicineService
    {
        public List<RejectedMedicine> GetAll()
        {
            return RejectedMedicineRepository.Instance.GetAllToList();
        }
        public bool Create(RejectedMedicine rejectedMedicine)
        {
            return  RejectedMedicineRepository.Instance.Create(rejectedMedicine);
        }

        public bool Update(RejectedMedicine entity)
        {
            throw new System.NotImplementedException();
        }

        public RejectedMedicine GetById(string key)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(string key)
        {
            throw new System.NotImplementedException();
        }

        public RejectedMedicine GetByMedicineId(string medId)
        {
            RejectedMedicine rejectedMedicine = new RejectedMedicine();
            foreach (var rm in GetAll())
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