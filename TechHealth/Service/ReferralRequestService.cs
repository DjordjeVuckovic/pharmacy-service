using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service.IService;

namespace TechHealth.Service
{
    public class ReferralRequestService:IReferralRequestService
    {
        public List<ReferralRequest> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Create(ReferralRequest referralRequest)
        {
            return ReferralRequestRepository.Instance.Create(referralRequest);
        }

        public bool Update(ReferralRequest entity)
        {
            throw new System.NotImplementedException();
        }

        public ReferralRequest GetById(string key)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(string key)
        {
            throw new System.NotImplementedException();
        }
    }
}