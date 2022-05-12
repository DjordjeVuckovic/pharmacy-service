using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class RejectedMedicineService
    {
        public void Create(RejectedMedicine rejectedMedicine)
        {
            RejectedMedicineRepository.Instance.Create(rejectedMedicine);
        }
    }
}