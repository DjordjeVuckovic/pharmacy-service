using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class PatientController
    {
        private readonly PatientService patientService = new PatientService();
        public List<Patient> GetAll()
        {
            return PatientRepository.Instance.GetAllToList();
        }
    }
}