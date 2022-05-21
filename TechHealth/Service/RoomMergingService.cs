using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class RoomMergingService
    {
        private RoomService roomService = new RoomService();
        private RoomEquipmentService roomEquipmentService = new RoomEquipmentService();
        public RoomMerging GetById(string mergeId)
        {
            return RoomMergingRepository.Instance.GetById(mergeId);
        }

        public List<RoomMerging> GetAll()
        {
            return RoomMergingRepository.Instance.GetAllToList();
        }

        public bool Create(RoomMerging rm)
        {
            return RoomMergingRepository.Instance.Create(rm);
        }

        public bool Update(RoomMerging rm)
        {
            return RoomMergingRepository.Instance.Update(rm);
        }

        public bool Delete(string mergeId)
        {
            return RoomMergingRepository.Instance.Delete(mergeId);
        }

        public void MergeRooms(RoomMerging rm)
        {
            Room room = roomService.GetRoombyId(rm.RoomOne);
            room.roomTypes = rm.RoomType;
            roomService.Update(room);
            roomService.Delete(rm.RoomTwo);

            roomEquipmentService.MoveEquipmentToWarehouse(rm.RoomOne, rm.RoomTwo);
        }
    }
}
