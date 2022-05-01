using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class TherapyController
    {
        private readonly TherapyService therapyService = new TherapyService();
        public void Create(Therapy therapy)
        {
            therapyService.Create(therapy);
        }
    }
}