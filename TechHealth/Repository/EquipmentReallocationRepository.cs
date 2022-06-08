using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.DTO;
using TechHealth.Repository.IRepository;

namespace TechHealth.Repository
{
    public class EquipmentReallocationRepository : GenericRepository<string, EquipmentReallocationDTO>,IEquipmentReallocationRepository
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
    }
}
