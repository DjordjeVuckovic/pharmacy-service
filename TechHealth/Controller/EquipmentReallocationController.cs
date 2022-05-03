using TechHealth.DTO;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class EquipmentReallocationController
    {
        private EquipmentReallocationService eqReallocationService = new EquipmentReallocationService();

        public bool Create(EquipmentReallocationDTO dto)
        {
            return eqReallocationService.Create(dto);
        }

        public void SubmitReallocation(EquipmentReallocationDTO dto)
        {
            eqReallocationService.SubmitReallocation(dto);
        }
    }
}
