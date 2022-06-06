using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service.IService;

namespace TechHealth.Service
{
    public class SpecializationService:ISpecializationService
    {
        public List<Specialization> GetAll()
        {
            return SpecializationRepository.Instance.GetAllToList();
        }

        public bool Create(Specialization entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Specialization entity)
        {
            throw new System.NotImplementedException();
        }

        public Specialization GetById(int key)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int key)
        {
            throw new System.NotImplementedException();
        }
    }
}