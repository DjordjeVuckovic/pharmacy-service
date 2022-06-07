using System.Collections.Generic;
using System.Collections.ObjectModel;
using TechHealth.Controller.IController;
using TechHealth.Model;
using TechHealth.Service;
using TechHealth.Service.IService;

namespace TechHealth.Controller
{
    public class TherapyController:ITherapyController
    {
        private readonly ITherapyService therapyService = new TherapyService();
        public void Create(Therapy therapy) => therapyService.Create(therapy);
        public void Update(Therapy entity)
        {
            throw new System.NotImplementedException();
        }

        public Therapy GetById(string key)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new System.NotImplementedException();
        }

        public List<Therapy> GetAll() => therapyService.GetAll();
        public List<Therapy> GetAllByPatientId(string patientId) => therapyService.GetAllByPatientId(patientId);
    }
}