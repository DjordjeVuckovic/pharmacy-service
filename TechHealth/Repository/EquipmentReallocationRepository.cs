using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.DTO;

namespace TechHealth.Repository
{
    public class EquipmentReallocationRepository : GenericRepository<string, EquipmentReallocationDTO>
    {
        private static readonly EquipmentReallocationRepository instance = new EquipmentReallocationRepository();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static EquipmentReallocationRepository()
        {
        }

        private EquipmentReallocationRepository()
        {
        }

        public static EquipmentReallocationRepository Instance => instance;
        protected override string GetKey(EquipmentReallocationDTO entity)
        {
            return entity.ReallocationID;
        }

        protected override string GetPath()
        {
            return @"../../Json/equipmentReallocation.json";
        }

        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }

        protected override void ShouldSerialize(EquipmentReallocationDTO entity)
        {
            entity.ShouldSerialize = true;
        }

        public bool IsReallocationHappening(DateTime? start, DateTime? end, string roomID)
        {
            foreach (var er in GetAllToList())
            {
                if (er.ReallocationTime >= start && er.ReallocationTime <= end && (er.DestinationRoomID == roomID || er.SourceRoomID == roomID))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
