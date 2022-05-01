using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class TherapyService
    {
        public void Create(Therapy therapy)
        {
            TherapyRepository.Instance.Create(therapy);
        }
    }
}