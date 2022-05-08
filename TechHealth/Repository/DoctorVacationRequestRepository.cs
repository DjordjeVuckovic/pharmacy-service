using TechHealth.Model;

namespace TechHealth.Repository
{
    public class DoctorVacationRequestRepository:GenericRepository<string,DoctorVacationRequest>
    {
        private static readonly DoctorVacationRequestRepository instance = new DoctorVacationRequestRepository();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static DoctorVacationRequestRepository()
        {
        }

        private DoctorVacationRequestRepository()
        {
        }

        public static DoctorVacationRequestRepository Instance => instance;
        protected override string GetPath()
        {
            return @"../../Json/doctorVacation.json";
        }

        protected override string GetKey(DoctorVacationRequest entity)
        {
            return  entity.VacationId;
        }

        protected override void RemoveAllReference(string key)
        {
            throw new System.NotImplementedException();
        }

        protected override void ShouldSerialize(DoctorVacationRequest entity)
        {
            entity.Doctor.ShouldSerialize = false;
        }
    }
}