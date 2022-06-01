using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class RoomRenovationController
    {
        private RoomRenovationService roomRenovationService = new RoomRenovationService();

        public List<RoomRenovation> GetAllToList()
        {
            return roomRenovationService.GetAllToList();
        }
        public bool Create(RoomRenovation rr)
        {
            return roomRenovationService.Create(rr);
        }

        public bool Update(RoomRenovation rr)
        {
            return roomRenovationService.Update(rr);
        }

        public bool Delete(string renovationId)
        {
            return roomRenovationService.Delete(renovationId);
        }
        public RoomRenovation GetRrByRoomID(string roomID)
        {
            return roomRenovationService.GetRrByRoomID(roomID);
        }

        public bool ExistsInRenovations(string roomID)
        {
            return roomRenovationService.ExistsInRenovations(roomID);
        }

        public bool IsValidDate(DateTime date, string src, string dst)
        {
            return roomRenovationService.IsValidDate(date, src, dst);
        }
    }
}
