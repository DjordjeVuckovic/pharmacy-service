using System.Collections.Generic;
using TechHealth.Controller.IController;
using TechHealth.Model;
using TechHealth.Service;
using TechHealth.Service.IService;

namespace TechHealth.Controller
{
    public class ReferralRequestController:IReferralRequestController
    {
        private readonly IReferralRequestService referralRequestService = new ReferralRequestService();
        public List<ReferralRequest> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Create(ReferralRequest referralRequest)
        {
            referralRequestService.Create(referralRequest);
        }

        public void Update(ReferralRequest entity)
        {
            throw new System.NotImplementedException();
        }

        public ReferralRequest GetById(string key)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new System.NotImplementedException();
        }
    }
}