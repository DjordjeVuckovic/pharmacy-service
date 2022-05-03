using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class AllergenService
    {
        public List<Allergen> GetAll()
        {
            return AllergensRepository.Instance.GetAllToList();
        }

        public bool Create(Allergen allergen)
        {
            return AllergensRepository.Instance.Create(allergen);
        }

        public bool Update(Allergen allergen)
        {
            return AllergensRepository.Instance.Update(allergen);
        }

        public bool Delete(string id)
        {
            return AllergensRepository.Instance.Delete(id);
        }
    }
}
