using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class RejectedMedicineController
    {
        private readonly RejectedMedicineService rejectedMedicineService = new RejectedMedicineService();
        public void Create(RejectedMedicine rejectedMedicine)
        {
            rejectedMedicineService.Create(rejectedMedicine);
        }
    }
}