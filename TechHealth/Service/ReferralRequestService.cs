using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class ReferralRequestService
    {
        public void Create(ReferralRequest referralRequest)
        {
            ReferralRequestRepository.Instance.Create(referralRequest);
        }
    }
}