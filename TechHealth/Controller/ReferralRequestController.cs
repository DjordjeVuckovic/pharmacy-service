using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class ReferralRequestController
    {
        private readonly ReferralRequestService referralRequestService = new ReferralRequestService();
        public void Create(ReferralRequest referralRequest)
        {
            referralRequestService.Create(referralRequest);
        }
    }
}