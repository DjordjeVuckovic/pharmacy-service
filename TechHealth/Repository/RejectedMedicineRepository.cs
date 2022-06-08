using TechHealth.Model;
using TechHealth.Repository.IRepository;

namespace TechHealth.Repository
{
    public class RejectedMedicineRepository:GenericRepository<string,RejectedMedicine>, IRejectedMedicineRepository
    {
        static RejectedMedicineRepository()
        {
        }

        private RejectedMedicineRepository()
        {
        }

        public static RejectedMedicineRepository Instance { get; } = new RejectedMedicineRepository();

        protected override string GetPath()
        {
            return @"../../Json/rejectedMedicine.json"; 
        }

        protected override string GetKey(RejectedMedicine entity)
        {
            return entity.RejectedMedicineId;
        }

        protected override void RemoveAllReference(string key)
        {
            throw new System.NotImplementedException();
        }

        protected override void ShouldSerialize(RejectedMedicine entity)
        {
            entity.Medicine.ShouldSerialize = false;
            entity.Doctor.ShouldSerialize = false;
        }
    }
}