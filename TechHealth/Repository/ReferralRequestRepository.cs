using TechHealth.Model;

namespace TechHealth.Repository
{
    public class ReferralRequestRepository:GenericRepository<string,ReferralRequest>
    {
        private static readonly ReferralRequestRepository instance = new ReferralRequestRepository();

        static ReferralRequestRepository()
        {
        }

        private ReferralRequestRepository()
        {
        }

        public static ReferralRequestRepository Instance => instance;
        protected override string GetPath()
        {
            return @"../../Json/referral.json"; 
        }

        protected override string GetKey(ReferralRequest entity)
        {
            return entity.ReferralId;
        }

        protected override void RemoveAllReference(string key)
        {
            throw new System.NotImplementedException();
        }

        protected override void ShouldSerialize(ReferralRequest entity)
        {
            entity.Appointment.ShouldSerialize=false;
            entity.ReferralDoctor.ShouldSerialize=false;
        }
    }
}