using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class RoomEquipmentController
    {
        private RoomEquipmentService roomEquipmentService = new RoomEquipmentService();

        public List<RoomEquipment> GetAllToList()
        {
            return roomEquipmentService.GetAll();
        }
        public bool Create(RoomEquipment re)
        {
            return roomEquipmentService.Create(re);
        }
        public bool Update(RoomEquipment re)
        {
            return roomEquipmentService.Update(re);
        }

        public bool Delete(string reID)
        {
            return roomEquipmentService.Delete(reID);
        }

        public void UpdateQuantityWithRequest(EquipmentRequest er)
        {
            RoomEquipment re = new RoomEquipment();
            re.EquipmentName = er.EquipmentName;
            re.Quantity = er.Quantity;
            roomEquipmentService.ExecuteMovement(re);
        }

        public List<RoomEquipment> GetRoomEqListByRoomID(string roomID)
        {
            return roomEquipmentService.GetRoomEqListByRoomID(roomID);
        }

        public List<RoomEquipment> GetRoomEqListByEqName(string eqName)
        {
            return roomEquipmentService.GetRoomEqListByEqName(eqName);
        }
        public bool ReEqExists(string eqName, string roomID)
        {
            return roomEquipmentService.ReEqExists(eqName, roomID);
        }

        public RoomEquipment GetReByKey(string eqName, string roomID)
        {
            return roomEquipmentService.GetReByKey(eqName, roomID);
        }
        public void DeleteRoomEqByEqName(List<RoomEquipment> reList)
        {
            roomEquipmentService.DeleteRoomEqByEqName(reList);
        }

        public void UpdateRoomEqByEqName(List<RoomEquipment> reList, string eqName)
        {
            roomEquipmentService.UpdateRoomEqByEqName(reList, eqName);
        }

        public bool UpdateWarehouseRoomEquipment(List<RoomEquipment> reList, Equipment equipment)
        {
            return roomEquipmentService.UpdateWarehouseRoomEquipment(reList, equipment);
        }

        public void CreateWarehouseRoomEquipment(RoomEquipment re, Equipment equipment)
        {
            roomEquipmentService.CreateWarehouseRoomEquipment(re, equipment);
        }
    }
}
