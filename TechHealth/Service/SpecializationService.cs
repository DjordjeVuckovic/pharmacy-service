using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class SpecializationService
    {
        public List<Specialization> GetAll()
        {
            return SpecializationRepository.Instance.GetAllToList();
        }
    }
}