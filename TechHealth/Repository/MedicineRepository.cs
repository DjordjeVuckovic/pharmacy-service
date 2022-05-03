using TechHealth.Model;

namespace TechHealth.Repository
{
    public class MedicineRepository : GenericRepository<string, Medicine>
    {
        private static readonly MedicineRepository instance = new MedicineRepository();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static MedicineRepository()
        {
        }

        private MedicineRepository()
        {
        }
        public static MedicineRepository Instance => instance;
        protected override string GetPath()
        {
            return @"../../Json/medicine.json";
        }

        protected override string GetKey(Medicine entity)
        {
            return entity.MedicineId;
        }

        protected override void RemoveAllReference(string key)
        {
            throw new System.NotImplementedException();
        }

        protected override void ShouldSerialize(Medicine entity)
        {
            entity.ShouldSerialize = true;
        }


    }
}