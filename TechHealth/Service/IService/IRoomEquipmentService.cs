using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Service.IService
{
    public interface IRoomEquipmentService:IService<RoomEquipment,string>
    {
        List<RoomEquipment> GetRoomEqListByRoomID(string roomID);
        List<RoomEquipment> GetRoomEqListByEqName(string eqName);
        bool ReEqExists(string eqName, string roomID);
        RoomEquipment GetReByKey(string eqName, string roomID);
        bool UpdateWarehouseRoomEquipment(List<RoomEquipment> reList, Equipment equipment);
        void CreateWarehouseRoomEquipment(RoomEquipment re, Equipment equipment);
        void DeleteRoomEqByEqName(List<RoomEquipment> reList);
        void UpdateRoomEqByEqName(List<RoomEquipment> reList, string eqName);
        void MoveEquipmentToWarehouse(string room1, string room2);
        void MoveEquipmentToWarehouse(string room);
        void DoEquipmentMovingToWarehouse(List<RoomEquipment> roomEquipment);
        bool EqExistsInWarehouse(RoomEquipment warehouseEq);
        void UpdateQuantity(RoomEquipment warehouseEq);
        void ExecuteMovement(RoomEquipment roomEq);
    }
}