using TechHealth.Model;

namespace TechHealth.Repository
{
    public class RejectedMedicineRepository:GenericRepository<string,RejectedMedicine>
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

        public RejectedMedicine GetByMedicineId(string medId)
        {
            RejectedMedicine rejectedMedicine = new RejectedMedicine();
            foreach (var rm in GetAllToList())
            {
                if (medId == rm.Medicine.MedicineId)
                {
                    rejectedMedicine = rm;
                    break;
                }
            }
            return rejectedMedicine;
        }
    }
}