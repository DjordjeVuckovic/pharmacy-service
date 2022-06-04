using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Conversions;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class RoomEquipmentService
    {
        public List<RoomEquipment> GetAllToList()
        {
            return RoomEquipmentRepository.Instance.GetAllToList();
        }
        public bool Create(RoomEquipment re)
        {
            return RoomEquipmentRepository.Instance.Create(re);
        }

        public bool Update(RoomEquipment re)
        {
            return RoomEquipmentRepository.Instance.Update(re);
        }

        public bool Delete(string reID)
        {
            return RoomEquipmentRepository.Instance.Delete(reID);
        }

        public List<RoomEquipment> GetRoomEqListByRoomID(string roomID)
        {
            List<RoomEquipment> eqList = new List<RoomEquipment>();
            foreach (var eq in GetAllToList())
            {
                if (eq.RoomID == roomID)
                {
                    eqList.Add(eq);
                }
            }
            return eqList;
        }

        public List<RoomEquipment> GetRoomEqListByEqName(string eqName)
        {
            List<RoomEquipment> eqList = new List<RoomEquipment>();
            foreach (var eq in GetAllToList())
            {
                if (eq.EquipmentName == eqName)
                {
                    eqList.Add(eq);
                }
            }
            return eqList;
        }
        public bool ReEqExists(string eqName, string roomID)
        {
            bool exists = false;
            foreach (var re in GetAllToList())
            {
                if (re.EquipmentName == eqName && re.RoomID == roomID)
                {
                    exists = true;
                }
            }
            return exists;
        }

        public RoomEquipment GetReByKey(string eqName, string roomID)
        {
            RoomEquipment re = new RoomEquipment();
            foreach (var r in GetAllToList())
            {
                if (r.RoomID == roomID && r.EquipmentName == eqName)
                {
                    re = r;
                    break;
                }
            }
            return re;
        }

        public bool UpdateWarehouseRoomEquipment(List<RoomEquipment> reList, Equipment equipment)
        {
            bool createRe = true;
            foreach (var re in reList)
            {
                if (re.EquipmentName == equipment.name && re.RoomID == ManagerConversions.RoomTypesToString(RoomTypes.warehouse))
                {
                    re.Quantity += equipment.quantity;
                    Update(re);
                    createRe = false;
                    break;
                }
            }
            return createRe;
        }

        public void CreateWarehouseRoomEquipment(RoomEquipment re, Equipment equipment)
        {
            re.EquipmentName = equipment.name;
            re.RoomID = ManagerConversions.RoomTypesToString(RoomTypes.warehouse);
            re.Quantity = equipment.quantity;
            Create(re);
        }

        public void DeleteRoomEqByEqName(List<RoomEquipment> reList)
        {
            foreach (var re in reList)
            {
                Delete(re.RoomID + "-" + re.EquipmentName);
            }
        }

        public void UpdateRoomEqByEqName(List<RoomEquipment> reList, string eqName)
        {
            foreach (var re in reList)
            {
                re.EquipmentName = eqName;
                Update(re);
            }
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
                    Update(wEq);
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
                Create(warehouseEq);
            }
                Delete(roomEq.RoomID + "-" + roomEq.EquipmentName);
        }
    }
}
