using System.Collections.Generic;
using System.Collections.ObjectModel;
using TechHealth.Model;
using TechHealth.Service;
using TechHealth.Service.IService;

namespace TechHealth.Controller
{
    public class TherapyController
    {
        private readonly ITherapyService therapyService = new TherapyService();
        public void Create(Therapy therapy) => therapyService.Create(therapy);

        public List<Therapy> GetAll() => therapyService.GetAll();
        public List<Therapy> GetAllByPatientId(string patientId) => therapyService.GetAllByPatientId(patientId);
    }
}