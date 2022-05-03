using System;
using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Repository
{
    public class RoomEquipmentRepository : GenericRepository<string, RoomEquipment>
    {
        private static readonly RoomEquipmentRepository instance = new RoomEquipmentRepository();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static RoomEquipmentRepository()
        {
        }

        private RoomEquipmentRepository()
        {
        }

        public static RoomEquipmentRepository Instance => instance;

        protected override string GetKey(RoomEquipment entity)
        {
            return entity.RoomID + "-" + entity.EquipmentName;
        }

        protected override string GetPath()
        {
            return @"../../Json/roomEquipment.json";
        }

        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }

        protected override void ShouldSerialize(RoomEquipment entity)
        {
            entity.ShouldSerialize = true;
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
            foreach (var re in GetAllToList())
            {
                if (re.EquipmentName == eqName && re.RoomID == roomID)
                {
                    return true;
                }
            }
            return false;
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
    }
}
