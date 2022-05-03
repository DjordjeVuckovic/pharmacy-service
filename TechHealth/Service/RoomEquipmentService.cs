using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class RoomEquipmentService
    {
        public bool Create(RoomEquipment re)
        {
            return RoomEquipmentRepository.Instance.Create(re);
        }
    }
}
