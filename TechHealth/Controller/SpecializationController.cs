using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Service;
using TechHealth.Service.IService;

namespace TechHealth.Controller
{
    public class SpecializationController
    {
        private readonly ISpecializationService specializationService = new SpecializationService();

        public List<Specialization> GetAll()
        {
            return specializationService.GetAll();
        }
    }
}