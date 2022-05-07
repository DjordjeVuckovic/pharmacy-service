using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class SpecializationController
    {
        private readonly SpecializationService specializationService = new SpecializationService();

        public List<Specialization> GetAll()
        {
            return specializationService.GetAll();
        }
    }
}