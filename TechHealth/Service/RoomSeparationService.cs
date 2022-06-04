using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class RoomSeparationService
    {
        private RoomEquipmentService roomEquipmentService = new RoomEquipmentService();
        public RoomSeparation GetById(string mergeId)
        {
            return RoomSeparationRepository.Instance.GetById(mergeId);
        }

        public List<RoomSeparation> GetAll()
        {
            return RoomSeparationRepository.Instance.GetAllToList();
        }

        public bool Create(RoomSeparation rs)
        {
            return RoomSeparationRepository.Instance.Create(rs);
        }

        public bool Update(RoomSeparation rs)
        {
            return RoomSeparationRepository.Instance.Update(rs);
        }

        public bool Delete(string separationId)
        {
            return RoomSeparationRepository.Instance.Delete(separationId);
        }

        public void SeparateRooms(RoomSeparation rs)
        {
            roomEquipmentService.MoveEquipmentToWarehouse(rs.RoomOne.RoomId);
        }

        public void SeparateOnDate(object state)
        {
            List<RoomSeparation> roomSeparation = new List<RoomSeparation>();
            roomSeparation = GetAll();
            foreach (var rs in roomSeparation)
            {
                if (DateTime.Compare(DateTime.Now, rs.SeparationEnd) == 0 || DateTime.Compare(rs.SeparationEnd, DateTime.Now) < 0)
                {
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        SeparateRooms(rs);
                        RoomSeparationRepository.Instance.Delete(rs.SeparationID);
                    });
                }
            }
        }
    }
}
