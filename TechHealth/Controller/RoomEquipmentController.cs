using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class RoomEquipmentController
    {
        private RoomEquipmentService roomInventoryService = new RoomEquipmentService();

        public bool Create(RoomEquipment re)
        {
            return roomInventoryService.Create(re);
        }
    }
}
