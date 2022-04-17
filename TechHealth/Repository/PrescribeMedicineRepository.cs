using TechHealth.Model;

namespace TechHealth.Repository
{
    public class PrescribeMedicineRepository:GenericRepository<string,Prescription>
    {
        private static PrescribeMedicineRepository instance;
        static PrescribeMedicineRepository()
        {
        }

        private PrescribeMedicineRepository()
        {
        }

        public static PrescribeMedicineRepository Instance => instance;
        protected override string GetPath()
        {
            return @"../../Json/prescription.json";
        }

        protected override string GetKey(Prescription entity)
        {
            return entity.PrescriptionId;
        }

        protected override void RemoveAllReference(string key)
        {
            throw new System.NotImplementedException();
        }
        
    }
}