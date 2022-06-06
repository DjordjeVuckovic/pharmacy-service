using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Service;
using TechHealth.Service.IService;

namespace TechHealth.Controller
{
    public class RoomSeparationController
    {
        private readonly IRoomSeparationService roomSeparationService = new RoomSeparationService();
        public RoomSeparation GetById(string mergeId)
        {
            return roomSeparationService.GetById(mergeId);
        }

        public List<RoomSeparation> GetAll()
        {
            return roomSeparationService.GetAll();
        }

        public bool Create(RoomSeparation rs)
        {
            return roomSeparationService.Create(rs);
        }

        public bool Update(RoomSeparation rs)
        {
            return roomSeparationService.Update(rs);
        }

        public bool Delete(string separationId)
        {
            return roomSeparationService.Delete(separationId);
        }

        public void SeparateRooms(RoomSeparation rs)
        {
            roomSeparationService.SeparateRooms(rs);
        }

        public void SeparateOnDate(object state)
        {
            roomSeparationService.SeparateOnDate(state);
        }
    }
}
