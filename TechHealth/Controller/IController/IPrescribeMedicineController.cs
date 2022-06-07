using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Controller.IController
{
    public interface IPrescribeMedicineController:IController<Prescription,string>
    {
        List<Prescription> GetAllByPatientId(string patientId);
        bool CheckAllergens(Medicine medicine, Patient patient);
    }
}