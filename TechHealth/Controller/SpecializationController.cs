using System.Collections.Generic;
using TechHealth.Controller.IController;
using TechHealth.Model;
using TechHealth.Service;
using TechHealth.Service.IService;

namespace TechHealth.Controller
{
    public class SpecializationController:ISpecializationController
    {
        private readonly ISpecializationService specializationService = new SpecializationService();

        public List<Specialization> GetAll()
        {
            return specializationService.GetAll();
        }

        public void Create(Specialization entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Specialization entity)
        {
            throw new System.NotImplementedException();
        }

        public Specialization GetById(int key)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new System.NotImplementedException();
        }
    }
}