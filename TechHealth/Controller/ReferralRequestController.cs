using TechHealth.Model;
using TechHealth.Service;
using TechHealth.Service.IService;

namespace TechHealth.Controller
{
    public class ReferralRequestController
    {
        private readonly IReferralRequestService referralRequestService = new ReferralRequestService();
        public void Create(ReferralRequest referralRequest)
        {
            referralRequestService.Create(referralRequest);
        }
    }
}