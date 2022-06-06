using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service.IService;

namespace TechHealth.Service
{
    public class RoomMergingService:IRoomMergingService
    {
        private IRoomService roomService = new RoomService();
        private IRoomEquipmentService roomEquipmentService = new RoomEquipmentService();
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
            room.RoomTypes = rm.RoomType;
            roomService.Update(room);
            roomService.Delete(rm.RoomTwo);

            roomEquipmentService.MoveEquipmentToWarehouse(rm.RoomOne, rm.RoomTwo);
        }

        public void MergeOnDate(object state)
        {
            List<RoomMerging> roomMergings = new List<RoomMerging>();
            roomMergings = GetAll();
            foreach (var rm in roomMergings)
            {
                if (DateTime.Compare(DateTime.Now, rm.MergeEnd) == 0 || DateTime.Compare(rm.MergeEnd, DateTime.Now) < 0)
                {
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        MergeRooms(rm);
                        RoomMergingRepository.Instance.Delete(rm.MergeID);
                    });
                }
            }
        }
    }
}
