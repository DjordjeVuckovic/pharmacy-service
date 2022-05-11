using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class RoomMergingController
    {
        private readonly RoomMergingService roomMergingService = new RoomMergingService();

        public RoomMerging GetById(string mergeId)
        {
            return roomMergingService.GetById(mergeId);
        }

        public List<RoomMerging> GetAll()
        {
            return roomMergingService.GetAll();
        }

        public bool Create(RoomMerging room)
        {
            return roomMergingService.Create(room);
        }

        public bool Update(RoomMerging rm)
        {
            return roomMergingService.Update(rm);
        }

        public bool Delete(string mergeId)
        {
            return roomMergingService.Delete(mergeId);
        }

        public void MergeRooms(RoomMerging rm)
        {
            roomMergingService.MergeRooms(rm);
        }
    }
}
