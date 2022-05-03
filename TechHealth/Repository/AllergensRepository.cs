using TechHealth.Model;

namespace TechHealth.Repository
{
    public class AllergensRepository:GenericRepository<string,Allergen>
    {
        private static readonly AllergensRepository instance = new AllergensRepository();
        
        static AllergensRepository()
        {
        }

        private AllergensRepository()
        {
        }
        public static AllergensRepository Instance => instance;
       

        protected override string GetPath()
        {
            return @"../../Json/allergens.json";
        }

        protected override string GetKey(Allergen entity)
        {
            return entity.Id;
        }

        protected override void RemoveAllReference(string key)
        {
            throw new System.NotImplementedException();
        }

        protected override void ShouldSerialize(Allergen entity)
        {
            //skip
        }
    }
}