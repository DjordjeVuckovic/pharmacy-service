using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class PatientAllergensService
    {
        public bool Create(PatientAllergens patientAllergens)
        {
            return PatientAllergensRepository.Instance.Create(patientAllergens);
        }
        public bool Update(PatientAllergens patientAllergens)
        {
            return PatientAllergensRepository.Instance.Update(patientAllergens);
        }
        public bool Delete(string id)
        {
            return PatientAllergensRepository.Instance.Delete(id);
        }
    }
}
