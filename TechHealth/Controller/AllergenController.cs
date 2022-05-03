using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class AllergenController
    {
        private readonly AllergenService allergenService = new AllergenService();
        public List<Allergen> GetAll()
        {
            return AllergensRepository.Instance.GetAllToList();
        }
        public bool Create(string id, string name, string description)
        {
            var allergen = new Allergen();

            allergen.Id = id;
            allergen.Name = name;
            allergen.Description = description;

            return allergenService.Create(allergen);
        }

        public bool Update(string id, string name, string description)
        {
            var allergen = new Allergen();

            allergen.Id = id;
            allergen.Name = name;
            allergen.Description = description;

            return allergenService.Update(allergen);
        }

        public bool Delete(string id)
        {
            return allergenService.Delete(id);
        }
    }
}
