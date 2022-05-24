using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class RoomEquipmentService
    {
        public bool Create(RoomEquipment re)
        {
            return RoomEquipmentRepository.Instance.Create(re);
        }

        public List<RoomEquipment> GetRoomEqListByRoomID(string roomID)
        {
            List<RoomEquipment> eqList = new List<RoomEquipment>();
            foreach (var eq in RoomEquipmentRepository.Instance.GetAllToList())
            {
                if (eq.RoomID == roomID)
                {
                    eqList.Add(eq);
                }
            }
            return eqList;
        }

        public void MoveEquipmentToWarehouse(string room1, string room2)
        {
            List<RoomEquipment> roomOneEquipment = GetRoomEqListByRoomID(room1);
            List<RoomEquipment> roomTwoEquipment = GetRoomEqListByRoomID(room2);
            DoEquipmentMovingToWarehouse(roomOneEquipment);
            DoEquipmentMovingToWarehouse(roomTwoEquipment);
        }
        public void MoveEquipmentToWarehouse(string room)
        {
            List<RoomEquipment> roomOneEquipment = GetRoomEqListByRoomID(room);
            DoEquipmentMovingToWarehouse(roomOneEquipment);
        }

        public void DoEquipmentMovingToWarehouse(List<RoomEquipment> roomEquipment)
        {
            foreach (var roomEq in roomEquipment)
            {
                ExecuteMovement(roomEq);
            }
        }

        public bool EqExistsInWarehouse(RoomEquipment warehouseEq)
        {
            bool exists = false;
            foreach (var wEq in GetRoomEqListByRoomID("Warehouse"))
            {
                if (wEq.EquipmentName.Equals(warehouseEq.EquipmentName))
                {
                    exists = true;
                    break;
                }
            }
            return exists;
        }

        public void UpdateQuantity(RoomEquipment warehouseEq)
        {
            foreach (var wEq in GetRoomEqListByRoomID("Warehouse"))
            {
                if (wEq.EquipmentName.Equals(warehouseEq.EquipmentName))
                {
                    wEq.Quantity += warehouseEq.Quantity;
                    RoomEquipmentRepository.Instance.Update(wEq);
                    return;
                }
            }
        }

        public void ExecuteMovement(RoomEquipment roomEq)
        {
            RoomEquipment warehouseEq = new RoomEquipment();
            warehouseEq.EquipmentName = roomEq.EquipmentName;
            warehouseEq.Quantity = roomEq.Quantity;
            warehouseEq.RoomID = "Warehouse";
            if (EqExistsInWarehouse(warehouseEq))
            {
                UpdateQuantity(warehouseEq);
            }
            else
            {
                RoomEquipmentRepository.Instance.Create(warehouseEq);
            }
            RoomEquipmentRepository.Instance.Delete(roomEq.RoomID + "-" + roomEq.EquipmentName);
        }
    }
}
