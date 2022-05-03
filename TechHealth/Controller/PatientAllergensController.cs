using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class PatientAllergensController
    {
        private PatientAllergensService patientAllergensService = new PatientAllergensService();

        public bool Create(PatientAllergens patientAllergens)
        {
            return patientAllergensService.Create(patientAllergens);
        }
        public bool Update(PatientAllergens patientAllergens)
        {
            return patientAllergensService.Update(patientAllergens);
        }
        public bool Delete(string id)
        {
            return patientAllergensService.Delete(id);
        }
    }
}
