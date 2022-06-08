using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.DTO;
using TechHealth.Service;
using TechHealth.Service.IService;

namespace TechHealth.Controller
{
    public class EquipmentReallocationController
    {
        private IEquipmentReallocationService eqReallocationService = new EquipmentReallocationService();

        public List<EquipmentReallocationDTO> GetAllToList()
        {
            return eqReallocationService.GetAll();
        }
        public bool Create(EquipmentReallocationDTO dto)
        {
            return eqReallocationService.Create(dto);
        }

        public void SubmitReallocation(EquipmentReallocationDTO dto)
        {
            eqReallocationService.SubmitReallocation(dto);
        }

        public void ReallocateOnDate(object state)
        {
            eqReallocationService.ReallocateOnDate(state);
        }

        public bool IsReallocationHappening(DateTime start, DateTime end, string roomID)
        {
            return eqReallocationService.IsReallocationHappening(start, end, roomID);
        }
    }
}
