using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Service.IService
{
    public interface IPrescribeMedicineService:IService<Prescription,string>
    {
        bool CheckAllergens(Medicine medicine, Patient patient);
        List<Prescription> GetAllByPatientId(string id);
        
    }
}