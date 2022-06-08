using TechHealth.Model;
using TechHealth.Repository.IRepository;

namespace TechHealth.Repository
{
    public class PrescribeMedicineRepository:GenericRepository<string,Prescription>,IPrescribeMedicineRepository
    {
        private static readonly PrescribeMedicineRepository instance= new PrescribeMedicineRepository();
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

        protected override void ShouldSerialize(Prescription entity)
        {
            entity.ShouldSerialize = true;
            entity.Appointment.ShouldSerialize = false;
            entity.Medicine.ShouldSerialize = false;

        }
    }
}